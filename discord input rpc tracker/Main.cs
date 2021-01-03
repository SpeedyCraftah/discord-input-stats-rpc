using DiscordRPC;
using System;
using System.Threading.Tasks;
using InputTracker;

namespace discord_input_rpc_tracker
{
    class Index
    {
        // Compact - Read only
        static readonly bool compact = false;

        static long KeysPressed = 0;
        static long LeftClicks = 0;

        static DateTime started_at;

        static DiscordRpcClient client;

        static void OnLeftClick()
        {
            LeftClicks++;
        }

        static void Main(string[] args)
        {
            MouseTracker.RegisterClicks(OnLeftClick);

            Console.WriteLine("Key tracker thread spawned.");

            client = new DiscordRpcClient("793662574088290325");

            client.Initialize();

            started_at = DateTime.Now;

            Console.WriteLine("Successfully started RPC in " + (compact ? "compact" : "full") + "mode.");
            Console.WriteLine("To exit, simply close the command prompt window.");

            Task.Run(async () => {
                while (true)
                {
                    if (compact)
                    {
                        client.SetPresence(new RichPresence()
                        {
                            Timestamps = new Timestamps(started_at),
                            Details = "Casually Tracking Mouse & Keyboard",
                            State = $"Left Clicks: {LeftClicks} | Keys Pressed: {KeysPressed}",
                            Assets = new Assets()
                            {
                                LargeImageKey = "keyboardandmouse",
                                LargeImageText = "stop hovering over me 😅",
                                SmallImageKey = "cslogo",
                                SmallImageText = "yes this was made in C#"
                            }
                        });
                    } else
                    {
                        client.SetPresence(new RichPresence()
                        {
                            Timestamps = new Timestamps(started_at),
                            Details = $"Left Clicks: {LeftClicks}",
                            State = $"Keys Pressed: {KeysPressed}",
                            Assets = new Assets()
                            {
                                LargeImageKey = "keyboardandmouse",
                                LargeImageText = "stop hovering over me 😅",
                                SmallImageKey = "cslogo",
                                SmallImageText = "yes this was made in C#"
                            }
                        });
                    }

                    await Task.Delay(15000);
                }
            });

            Console.WriteLine("Main thread spawned.");

            Console.ReadLine();
        }
    }
}
