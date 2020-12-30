# Edit this to 'True' if you would like both the keys and clicks
# To fit on most displays (removes 'casually tracking' text to do so).
compact = False

from pypresence import Presence
from datetime import datetime
import threading
import keyboard_input as keyboard
import mouse_input as mouse
import time

client_id = "793662574088290325"
RPC = Presence(client_id)
RPC.connect()

started_at = int(round(time.time() * 1000))
keys_pressed = 0
mouse_clicks = 0

def on_click():
    global mouse_clicks
    mouse_clicks += 1


def on_key_press(key):
    global keys_pressed
    keys_pressed += 1

keyboard.register_keys(on_key_press)
mouse.register_clicks(on_click)

def main():
    global keys_pressed
    global mouse_clicks

    print(f"Successfully started RPC in {'compact' if compact == True else 'full'} mode.")
    print("To exit, simply close the command prompt window.")

    while True:
        if compact == False:
            RPC.update(
                start=started_at,
                state=f"Keys Pressed: {keys_pressed} | Left Clicks: {mouse_clicks}",
                large_image="keyboardandmouse",
                large_text="stop hovering over me 😅",
                details="Casually Tracking Mouse & Keyboard",
                small_image="pylogo",
                small_text="yes this was made in python"
            )
        else:
            RPC.update(
                start=started_at,
                state=f"Left Clicks: {mouse_clicks}",
                large_image="keyboardandmouse",
                large_text="stop hovering over me 😅",
                details=f"Keys Pressed: {keys_pressed}",
                small_image="pylogo",
                small_text="yes this was made in python"
            )

        # respecting rate limits even though I hate discord :)
        time.sleep(15)

threading.Thread(target=main).start()
print("Main thread spawned.")
