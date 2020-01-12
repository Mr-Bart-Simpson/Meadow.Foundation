﻿using System;
using System.Threading;
using Meadow;
using Meadow.Devices;
using Meadow.Foundation;
using Meadow.Foundation.Displays.Tft;
using Meadow.Foundation.Graphics;
using Meadow.Hardware;

namespace Displays.Tft.ST7789_Sample
{
    public class MeadowApp : App<F7Micro, MeadowApp>
    {
        GraphicsLibrary graphicsLib;
        DisplayTftSpiBase display;
        ISpiBus spiBus;

        public MeadowApp()
        {
            Console.WriteLine("TftSpi sample");

            Initialize();

            while (true)
            {
                FontScaleTest();
                Thread.Sleep(5000);

                ColorFontTest();
                Thread.Sleep(5000);
            }
        }

        void Initialize()
        {
            Console.WriteLine("Create Spi bus");

            var config = new SpiClockConfiguration(6000, SpiClockConfiguration.Mode.Mode3);
            spiBus = Device.CreateSpiBus(Device.Pins.SCK, Device.Pins.MOSI, Device.Pins.MISO, config);

            Console.WriteLine("Create display driver instance");

            display = new St7789(device: Device, spiBus: spiBus,
                chipSelectPin: Device.Pins.D02,
                dcPin: Device.Pins.D01,
                resetPin: Device.Pins.D00,
                width: 240, height: 240);

            Console.WriteLine("Create graphics lib");

            graphicsLib = new GraphicsLibrary(display);
        }

        void FontScaleTest()
        {
            graphicsLib.CurrentFont = new Font12x20();

            graphicsLib.Clear();

            graphicsLib.DrawText(0, 0, "2x Scale", Color.Blue, GraphicsLibrary.ScaleFactor.X2);

            graphicsLib.DrawText(0, 48, "12x20 Font", Color.Green, GraphicsLibrary.ScaleFactor.X2);

            graphicsLib.DrawText(0, 96, "0123456789", Color.Yellow, GraphicsLibrary.ScaleFactor.X2);

            graphicsLib.DrawText(0, 144, "!@#$%^&*()", Color.Orange, GraphicsLibrary.ScaleFactor.X2);

            graphicsLib.DrawText(0, 192, "3x!", Color.OrangeRed, GraphicsLibrary.ScaleFactor.X3);


            graphicsLib.Show();
        }

        void ColorFontTest()
        {
            graphicsLib.CurrentFont = new Font8x12();

            graphicsLib.Clear();

            graphicsLib.DrawTriangle(120, 20, 200, 100, 120, 100, Meadow.Foundation.Color.Red, false);

            graphicsLib.DrawRectangle(140, 30, 40, 90, Meadow.Foundation.Color.Yellow, false);

            graphicsLib.DrawCircle(160, 80, 40, Meadow.Foundation.Color.Cyan, false);

            int indent = 5;
            int spacing = 14;
            int y = indent;

            graphicsLib.DrawText(indent, y, "Meadow F7 SPI ST7789!!");

            graphicsLib.DrawText(indent, y += spacing, "Red", Meadow.Foundation.Color.Red);

            graphicsLib.DrawText(indent, y += spacing, "Purple", Meadow.Foundation.Color.Purple);

            graphicsLib.DrawText(indent, y += spacing, "BlueViolet", Meadow.Foundation.Color.BlueViolet);

            graphicsLib.DrawText(indent, y += spacing, "Blue", Meadow.Foundation.Color.Blue);

            graphicsLib.DrawText(indent, y += spacing, "Cyan", Meadow.Foundation.Color.Cyan);

            graphicsLib.DrawText(indent, y += spacing, "LawnGreen", Meadow.Foundation.Color.LawnGreen);

            graphicsLib.DrawText(indent, y += spacing, "GreenYellow", Meadow.Foundation.Color.GreenYellow);

            graphicsLib.DrawText(indent, y += spacing, "Yellow", Meadow.Foundation.Color.Yellow);

            graphicsLib.DrawText(indent, y += spacing, "Orange", Meadow.Foundation.Color.Orange);

            graphicsLib.DrawText(indent, y += spacing, "Brown", Meadow.Foundation.Color.Brown);


            graphicsLib.Show();

            Console.WriteLine("Show complete");
        }
    }
}