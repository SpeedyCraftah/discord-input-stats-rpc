using DiscordRPC;
using System;
using System.Threading.Tasks;
using static discord_input_rpc_tracker.KeyboardTracker;

namespace discord_input_rpc_tracker
{
    class Index
    {
        static readonly bool compact = false;

        static int keys_pressed = 0;

        static DateTime started_at;

        static DiscordRpcClient client;

        static void Main(string[] args)
        {
            RegisterKeys(() =>
            {
                keys_pressed++;
            });

            Console.WriteLine("Key hook attached.");

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
                            State = $"Keys Pressed: {keys_pressed}",
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
                            // Details - Mouse Clicks
                            State = $"Keys Pressed: {keys_pressed}",
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
        }
    }
}
