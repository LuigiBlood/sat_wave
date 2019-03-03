SatellaWave 0.5.0 (2019-03-??)
by LuigiBlood

This software can make Satellaview compatible server binary files.
A tree of channels is managed by the user and it is possible to save, then load a repository of channels with all their attributes.
You can then export to binary files compatible with SNES emulators that supports them.

As of this time of writing, the SNES emulators that supports such files are:
- bsnes-plus v074 and later (in bsxdat folder)
- SNES9X 1.56 and later (in SatData folder by default)

Currently supported channels:
- Message Channel
- Town Status
- Directory
	- Folders
		- Files (also Include Files)
		- Items
	- Expansion - Event Plaza
	- Expansion - Script
- Patch
- Time Channel (BS-X - Global)
- Time Channel (Game Specific)
- Shigesato Itoi no Bass Fishing No. 1 Contest Channels

Notes about SuperFamiconv:
SuperFamiconv (by Optiroc) can be found here for Custom Event Plaza Buildings: https://github.com/Optiroc/SuperFamiconv
Make sure the palette mode has subpalettes set to 1 (-P 1), and map mode is for 8x14 tilemap.
To make it easier, the original picture has to be 64x112 (you can still cheat a bit).

Changelog:
0.5.0 (2019-03-??)
- Basic Script Expansion File Import
- Fix Padding to prevent Tile Copy bug
- Update People List with Bakusho Mondai names
- Add option to reset all data on Event Plaza Editor [LittleToonCat]
- Fix 'Edit Event Plaza Building' toolstrip [LittleToonCat]
- Always update display when importing graphics to Event Plaza Editor [LittleToonCat]
- Update edited generic channel names
- Focus on Channel name when editing the channel info

0.4.0 (2018-07-12)
- Full Event Plaza Expansion Support
- Automatically adapt the header for Memory Pack downloads
- Prevent making too many files in folders
- Update Window when you create a new / load repository (bugfix)
- Unix ready support for Export (bugfix) [LittleToonCat]
- Fix SNES Patch loading from repository (bugfix) [LittleToonCat]
- Fix latest BS-X Patch (bugfix, now it works)
NOTE: As of this release, all aforementioned emulators fully supports file downloads now. I suggest to use the latest BS-X Patch channel for stable downloads in BS-X.

0.3.1 (2018-01-09)
- Prevent Folder and File Descriptions to be too long.
- Automatically select the recommended file destination after browsing the file.
- BS-X Patch Support (Official BS-X Update & Custom Patches)
- Warn User if Software Channel and/or Logical Channel already exists after editing the channel.
- Software Channel detection now detects Directory.
- Before Export, Repository will be checked for conflicts.

0.3 (2018-01-05)
- Fix CheckUsedLCI() which didn't take into account directories themselves (fixes hang in BS-X).
- [Special Event] is now [Hydrant Access].
- Exporting now changes the Town ID and Directory ID. This allows to change the satellite data in real time as it is emulated if you directly export to the folder.
NOTE: As said earlier in the readme, current stable versions of emulators do not support file downloads properly.

0.2 (2018-01-04)
- Prevent User from choosing more than 5 NPCs/Events (with exceptions).
- Streamed File signification a little clearer (and prevent use of it).
- Added feedback when the folder/file name is too long.
- Prevent new lines for item descriptions.
- Warn user if BS-X will not react properly to the exported bin files.
- Show Current XML filepath in window title [ToontownLittleCat]

0.1 (2017-12-29)
- Initial release