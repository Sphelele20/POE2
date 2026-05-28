using System.Media;

namespace SmartChat.Services
{
    public static class VoiceService
    {
        public static void PlayGreeting()
        {
            SystemSounds.Beep.Play();
        }
    }
}
