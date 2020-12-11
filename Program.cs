/*
 *Лабораторная: 2.2.
 *Источник: Hwmw.Blogspot.com
 *
 *Язык: C Sharp (C#) v7.3.
 *Среда: Microsoft Visual Studio 2019 v16.7.6.
 *Платформа: .NET Framework v4.7.2.
 *API: console.
 *Изменение: 13.11.2020.
 *Защита: 13.11.2020.
 *
 *Задание: разработайте приложение. В папке приложения находится папка PLUGINS с динамическими библиотеками, содержащими функции
 *     TheFunc(x: Double): Double (cdecl) и функцию FuncName: PAnsiChar (stdcall). Приложение загружает библиотеки, выводит
 *     имена функций и спрашивает пользователя какую функцию посчитать. После ответа, программа либо строит график на интервале
 *     от 0 до 10 и подписывает его названием функции. Если библиотеку загрузить не удалось или функции не найдены, то она
 *     пропускается. 
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;

namespace SourceNamespace {

    public interface DLLInterface {
        double CalFunction (double x);
        string CalFunctionName ();
    }

    public class LibDLL: DLLInterface {

        [DllImport("Lib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double TheFunc (double x);

        [DllImport("Lib.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern IntPtr FuncName ();

        public double CalFunction (double x) {
            try {
                return TheFunc (x);
            }
            catch {
                throw new Exception ("Возникла ошибка при построении графика.");
            }
        }

        public string CalFunctionName () {
            try {
                return Marshal.PtrToStringAnsi(FuncName());
            }
            catch {
                return "--";
            }
        }
    }

    public class LibDLL2: DLLInterface {

        [DllImport ("Lib2-2-1.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double TheFunc (double x);

        [DllImport ("Lib2-2-1.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern IntPtr FuncName ();

        public double CalFunction (double x) {
            try {
                return TheFunc (x);

            }
            catch {
                throw new Exception("Возникла ошибка при построении графика.");
            }
        }

        public string CalFunctionName () {
            try {
                return Marshal.PtrToStringAnsi (FuncName ());
            }
            catch {
                return "--";
            }
        }
    }

    public class LibDLL3: DLLInterface {

        [DllImport("Lib2-2-2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double TheFunc (double x);

        [DllImport("Lib2-2-2.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern IntPtr FuncName ();

        public double CalFunction (double x) {
            try {
                return TheFunc (x);
            }
            catch {
                throw new Exception ("Возникла ошибка при построении графика.");
            }
        }

        public string CalFunctionName () {
            try {
                return Marshal.PtrToStringAnsi (FuncName ());
            }
            catch {
                return "--";
            }
        }
    }

    public class LibDLL4: DLLInterface {
        [DllImport("Lib2-2-3-1.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double TheFunc (double x);

        [DllImport("Lib2-2-3-1.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern IntPtr FuncName ();

        public double CalFunction (double x) {
            try {
                return TheFunc (x);
            }
            catch {
                throw new Exception ("Ошибка построения графика.");
            }
        }
        public string CalFunctionName () {
            try {
                return Marshal.PtrToStringAnsi (FuncName ());
            }
            catch {
                return "--";
            }
        }
    }

    public class LibDLL5: DLLInterface {
        [DllImport("Lib2-2-3-2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double TheFunc (double x);

        [DllImport("Lib2-2-3-2.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern IntPtr FuncName ();

        public double CalFunction (double x) {
            try {
                return TheFunc (x);
            }
            catch {
                throw new Exception("Ошибка построения графика.");
            }
        }
        public string CalFunctionName () {
            try {
                return Marshal.PtrToStringAnsi (FuncName ());
            }
            catch {
                return "--";
            }
        }
    }

    public class LibDLL6: DLLInterface {
        [DllImport("Lib2-2-3.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double TheFunc (double x);

        [DllImport("Lib2-2-3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern IntPtr FuncName ();

        public double CalFunction (double x) {
            try {
                return TheFunc (x);
            }
            catch {
                throw new Exception ("Ошибка построения графика.");
            }
        }
        public string CalFunctionName () {
            try {
                return Marshal.PtrToStringAnsi (FuncName ());
            }
            catch {
                return "--";
            }
        }
    }

    class Program {

        public static void GetGraph (DLLInterface dll) {
            const double Step = 0.5;
            const double MinX = 0;
            const double MaxX = 10;
            const string Img = "Chart.png";
            var xList = new List<double> ();
            var yList = new List<double> ();
            for (var xx = MinX; xx <= MaxX; xx += Step) {
                var res = dll.CalFunction (xx);
                xList.Add (xx);
                yList.Add (res);
            }

            using (Bitmap bmp = new Bitmap (1000, 1000)) {
                using (Graphics g = Graphics.FromImage (bmp)) {                    
                    g.Clear (Color.White);
                    Font font = new Font ("Arial", 10);
                    SolidBrush Brush = new SolidBrush (Color.Black);
                    Pen blackPen = new Pen (Color.Black, 3);
                    Pen redPen = new Pen (Color.Red, 3);
                    int centre = bmp.Width / 2;
                    g.TranslateTransform (centre, centre);
                    g.DrawString (dll.CalFunctionName (), font, Brush, new PointF (50.0f, 50.0f));
                    g.ScaleTransform (1, -1);
                    g.DrawLine (blackPen, 0, centre, 0, -centre);
                    g.DrawLine (blackPen, -centre, 0, centre, 0);
                    var PointList = new PointF [yList.Count];
                    for (int i = 0; i < yList.Count; i++) {
                        var p = new PointF ((float) xList [i] * 5, (float) yList [i] * 5);
                        PointList[i] = p;
                    }
                    g.DrawLines (redPen, PointList);
                }
                bmp.Save ("C:\\" + Img, System.Drawing.Imaging.ImageFormat.Png);                
            }
            Console.Write ("\nГрафик успешно построен.");
        }

        static void Main() {
            List <DLLInterface> dllList = new List <DLLInterface> {
                new LibDLL (),
                new LibDLL2 (),
                new LibDLL3 (),
                new LibDLL4 (),
                new LibDLL5 (),
                new LibDLL6 ()
            };
            List <int> IsFunc = new List <int> ();
            for (int i =0; i< dllList.Count; i++) {
                if (dllList[i].CalFunctionName() != "--") {
                    IsFunc.Add (i);
                }
            }
            Console.Write ("Функции, доступные в динамических библиотеках:\n\n");
            if (IsFunc.Count == 0) {
                Console.Write ("В библиотеках нет ни одной функции.");
            }
            for (int j = 0; j < IsFunc.Count; j++) {
                Console.Write ($"{IsFunc [j] + 1}. {dllList [IsFunc [j]].CalFunctionName ()}\n");
            }
            try {
                Console.Write ("\nВаш выбор: ");
                int choice = Convert.ToInt32 (Console.ReadLine ());
                GetGraph (dllList [choice - 1]);
            }
            catch {
                Console.Write ("\nОшибка ввода данных. Программа завершает свою работу.");
            }
            finally {
                Console.Write ("\n\nДля продолжения нажмите любую клавишу . . . ");
                Console.ReadKey ();
                Environment.Exit (0);
            }
        }
    }
}
