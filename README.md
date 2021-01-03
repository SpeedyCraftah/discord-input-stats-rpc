# discord-input-stats-rpc
This small module written in C# tracks the amount of times you've pressed a key on your keyboard and the amount of left clicks on your mouse and displays them in your Discord RPC! 

- Trace amounts of CPU usage (&lt;1% occasionally) and memory (~7mb 64-bit, ~3mb 32-bit)
- Key contents are not logged
- Bundled into `.exe` for easier use
- Small hidden easter eggs in big and small image text:) (you can change them if you don't like them)

# How to build from source (not recommended)
- Clone this repository in Visual Studio
- Install all required packages and build

# Python?
Switch to the [Python](https://github.com/SpeedyCraftah/discord-input-stats-rpc/tree/python) branch (no executables).

# Windows Defender detects as malware?
Unforunately due to the `.exe` being unsigned (which costs a fortune for a free project) Windows Defender tends to block programs like these due to them being 'untrusted'. 
However you can look at the virus total if you're unsure!

[Virus Total Results](https://www.virustotal.com/gui/file/7fed8a10dc8f678c4bc681d2349baf7086dfcaeeabdb16cf5f0d04fb2414ea11/detection) | 
[Virus Total Behaviour Report](https://www.virustotal.com/gui/file/b8a48d282c2629ef0e393f3c96bcd2b82fc0c39a3f97f905a7623ddbe1777f9e/behavior/VirusTotal%20Jujubox)

As expected, it was only detected by 2 overprotective antivirus software out of 65 engines, they were both marked as 'unsafe'.


**.Net Framework 4.7 or above is required! (most Windows versions already come with this)**
**Only Windows is supported at this time.**
