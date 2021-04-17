using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeepSkyDad.MusicChairs
{
    //simple music chairs app that pauses music randomly, for kids game :) 
    class Program
    {
        const int NEXT_TRACK = 0xB0;
        const int PLAY_PAUSE = 0xB3;
        const int PREV_TRACK = 0xB1;
        const int STOP = 0xB7;
        private static Random rnd = new Random();

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte key, byte code, uint flgs, IntPtr ptr);

        static void Main(string[] args)
        {
            keybd_event(STOP, 0, 1, IntPtr.Zero);
            keybd_event(PLAY_PAUSE, 0, 1, IntPtr.Zero);

            while (true)
            {
                var playDuratino = rnd.Next(10, 20);
                Thread.Sleep(rnd.Next(10, 20));
                keybd_event(PLAY_PAUSE, 0, 1, IntPtr.Zero);
                Thread.Sleep(rnd.Next(2, 8));
            }
            
        }
    }
}
