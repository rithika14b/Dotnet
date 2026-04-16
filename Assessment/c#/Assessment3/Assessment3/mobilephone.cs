using System;

namespace Assessment3
{
    class MobilePhone
    {
        public delegate void RingEventHandler();
        public event RingEventHandler OnRing;
   
        public void ReceiveCall()
        {
            Console.WriteLine("Incoming call...");           
            OnRing?.Invoke();
        }
    }

    class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }

    class ScreenDisplay
    {
        public void ShowCallerInfo()
        {
            Console.WriteLine("Displaying caller information...");
        }
    }

    class VibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating...");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MobilePhone phone = new MobilePhone();

            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay screen = new ScreenDisplay();
            VibrationMotor vibration = new VibrationMotor();


            phone.OnRing += ringtone.PlayRingtone;
            phone.OnRing += screen.ShowCallerInfo;
            phone.OnRing += vibration.Vibrate;


            phone.ReceiveCall();
        }
    }

}
