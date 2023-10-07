﻿using System;

namespace Meadow.Foundation.Displays
{
    /// <summary>
    /// Provide an interface to the SSD1306 family of OLED displays.
    /// </summary>
    public abstract partial class Ssd130xBase
    {
        //The buffers below are instantiated on demand so we're not creating unused buffers 
        //These should only be accessed once so no performance penalty 

        /// <summary>
        /// Sequence of bytes that should be sent to a 128x64 OLED display to setup the device.
        /// </summary>
        protected Span<byte> Oled128x64SetupSequence => new byte[]
        {
            0xae, 0xd5, 0x80, 0xa8, 0x3f, 0xd3, 0x00, 0x40 | 0x0, 0x8d, 0x14, 0x20, 0x00, 0xa0 | 0x1, 0xc8,
            0xda, 0x12, 0x81, 0xcf, 0xd9, 0xf1, 0xdb, 0x40, 0xa4, 0xa6, 0xaf
        };

        /// <summary>
        /// Sequence of bytes that should be sent to a 128x32 OLED display to setup the device.
        /// </summary>
        protected Span<byte> Oled128x32SetupSequence => new byte[]
        {
            0xae, 0xd5, 0x80, 0xa8, 0x1f, 0xd3, 0x00, 0x40 | 0x0, 0x8d, 0x14, 0x20, 0x00, 0xa0 | 0x1, 0xc8,
            0xda, 0x02, 0x81, 0x8f, 0xd9, 0x1f, 0xdb, 0x40, 0xa4, 0xa6, 0xaf
        };

        /// <summary>
        /// Sequence of bytes that should be sent to a 72x40 OLED display to setup the device.
        /// </summary>
        protected Span<byte> Oled72x40SetupSequence => new byte[]
        {
            0xae, 0xd5, 0x80, 0xa8, 0x27, 0xd3, 0x00, 0xad, 0x30, 0x40, 0x8d, 0x14, 0x20, 0x00, 0xa1, 0xc8,
            0xda, 0x12, 0x81, 0xcf, 0xd9, 0xf1, 0xdb, 0x40, 0xa4, 0xa6, 0xaf
        };

        /// <summary>
        /// Sequence of bytes that should be sent to a 96x16 OLED display to setup the device.
        /// </summary>
        protected Span<byte> Oled96x16SetupSequence => new byte[]
        {
            0xae, 0xd5, 0x80, 0xa8, 0x1f, 0xd3, 0x00, 0x40 | 0x0, 0x8d, 0x14, 0x20, 0x00, 0xa0 | 0x1, 0xc8,
            0xda, 0x02, 0x81, 0xaf, 0xd9, 0x1f, 0xdb, 0x40, 0xa4, 0xa6, 0xaf
        };
        /// <summary>
        /// Sequence of bytes that should be sent to a 64x48 OLED display to setup the device.
        /// </summary>
        protected Span<byte> Oled64x48SetupSequence => new byte[]
        {
            0xae, 0xd5, 0x80, 0xa8, 0x3f, 0xd3, 0x00, 0x40 | 0x0, 0x8d, 0x14, 0x20, 0x00, 0xa0 | 0x1, 0xc8,
            0xda, 0x12, 0x81, 0xcf, 0xd9, 0xf1, 0xdb, 0x40, 0xa4, 0xa6, 0xaf
        };
    }
}
