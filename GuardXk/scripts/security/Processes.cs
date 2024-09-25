using System;
using System.Diagnostics;
using System.Threading;

namespace GuardXk.Security{
    public class Processes{
        bool isRuntime = false;
        public int Interval { get; set; }
        public bool IsRuntime { get{return isRuntime;} }
        public Processes(int interval = 5000){
            Interval = interval;
        }

        public void Start(){
            if(!IsRuntime){
                isRuntime = true;
                new Thread(Check).Start();
            }
        }

        public void Stop(){
            isRuntime = false;
        }

        static string[] processes = {"cheatengine", "otherhacktool", "notepad"};

        public void Check(){
            if(IsRuntime){
                foreach(string process in processes){
                    if(Process.GetProcessesByName(process).Length > 0)
                        Console.WriteLine("Cheat detected!");
                }
                Thread.Sleep(Interval);
                Check();
            }
        }
    }
}