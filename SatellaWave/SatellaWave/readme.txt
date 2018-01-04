SatellaWave 0.2 (2018-01-04)
by LuigiBlood

This software can make Satellaview compatible server binary files.
A tree of channels is managed by the user and it is possible to save, then load a repository of channels with all their attributes.
You can then export to binary files compatible with SNES emulators that supports them.

As of this time of writing, the SNES emulators that supports such files are:
- bsnes-plus v073+3 and later (in bsxdat folder)
- SNES9X 1.55 and later (in SatData folder)

However, the bigger files to be downloaded are only supported in development versions from LuigiBlood, so you may have to compile those versions yourself (repositories can be found at https://github.com/LuigiBlood).

Currently supported channels:
- Message Channel
- Town Status
- Directory
	- Folders
		- Files (also Include Files)
		- Items
- Time Channel (BS-X - Global)
- Time Channel (Game Specific)
- Shigesato Itoi no Bass Fishing No. 1 Contest Channels

Changelog:
0.2 (2018-01-04)
- Prevent User from choosing more than 5 NPCs/Events (with exceptions).
- Streamed File signification a little clearer (and prevent use of it).
- Added feedback when the folder/file name is too long.
- Prevent new lines for item descriptions.
- Warn user if BS-X will not react properly to the exported bin files.
- Show Current XML filepath in window title [ToontownLittleCat]

0.1 (2017-12-29)
- Initial release