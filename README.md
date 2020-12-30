# discord-input-stats-rpc
This small module written in python tracks the amount of times you've pressed a key on your keyboard and the amount of left clicks on your mouse and displays them in your Discord RPC! 

- Trace amounts of CPU usage (&lt;1%) and memory (~30mb)
- Key contents are not logged
- ~~Bundled into `.exe` for easier use~~
- Small hidden easter eggs in big and small image text:) (you can change them if you don't like them)

# How to manually setup
- Clone this repository into a folder
- Install all packages in `requirements.txt` (I recommend making a virtual env first with `py -m venv env` and `./env/Scripts/activate`)
- If you want to run in compact mode, open `main.py` and change the first variable to `True`
- Run `main.py`

# Why are there no executables?
- You are on the wrong branch, executables are on the [master branch](https://github.com/SpeedyCraftah/discord-input-stats-rpc/tree/master)
- Almost every anti-virus software detects `.exe` files compiled by [PyInstaller](https://github.com/pyinstaller/pyinstaller) as malware
- For some unknown reason, I have failed to compile `.exe` files as they result in an error, so if you insist on running the Python version you will have to follow the manual setup

**Only windows is supported at this time.**
