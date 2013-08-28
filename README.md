PicKit2 Editor
==============

Pickit2 Device File Script Editor

This program was built so I could add Microchip's new PIC24FJxxDAxxx series chips to my PicKit2, 
which it doesn't currently support.
To do this, I developed a script decompiler so I could understand the script format, 
and change the necessary bytes to make it compataible with the new chips.

This program also has a patcher tool which adds these chips automatically to your pk2 device file, 
and also has a 'New Part' wizard which should make adding new chips a lot easier.

It doesn't have all the features of dougy83's PicKit2 Device File Editor,
so it's mostly useful for the script editor and device patcher.

It should be relatively easy to add extra chips to my device file patcher wizard, 
so if you want any added, open an issue or add it yourself!

You can find more information about this project on my blog:
http://jared.geek.nz/2013/aug/pickit2-revisited

![Screenshot](http://jared.geek.nz/pickit2-revisited/files/PicKit2%20Editor.png)

## Downloads

[PK2Editor.zip](http://jared.geek.nz/media/PK2Editor.zip)

[Patched PK2DeviceFile.dat](http://jared.geek.nz/media/PK2DeviceFile.dat)

#### Supported Chips

> PIC24FJ128DA106, PIC24FJ256DA106, PIC24FJ128DA110, PIC24FJ256DA110, PIC24FJ128DA206, 
PIC24FJ256DA206, PIC24FJ128DA210, PIC24FJ256DA210, 
PIC24FJ64GA306, PIC24FJ64GA308, PIC24FJ64GA310, PIC24FJ128GA306, 
PIC24FJ128GA308, PIC24FJ128GA310, PIC24FJ128GB206, PIC24FJ256GB206, 
PIC24FJ128GB210, PIC24FJ256GB210, PIC24FJ64GC006, PIC24FJ64GC008, PIC24FJ64GC010, 
PIC24FJ128GC006, PIC24FJ128GC008, PIC24FJ128GC010
