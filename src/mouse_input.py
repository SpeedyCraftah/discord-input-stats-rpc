import threading
import win32api
import time

state_left = win32api.GetKeyState(0x01)

def __run__(left_click):
    global state_left
    
    while True:
        a = win32api.GetKeyState(0x01)

        if a != state_left:  # Button state changed
            state_left = a
            if a < 0:
                if left_click:
                    left_click()

        time.sleep(0.001)

def register_clicks(left_click):
    threading.Thread(target=__run__, args=(left_click,)).start()
    print("Mouse click tracker thread spawned.")
