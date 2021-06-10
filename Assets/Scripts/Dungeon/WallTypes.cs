using System.Collections.Generic;

namespace Dungeon
{
    public static class WallTypes
    {
        public static readonly HashSet<int> WallTop = new HashSet<int>
        {
            0b0001,
            0b0011,
            0b0101,
            0b0111,
            0b1001,
            0b1011,
            0b1100,
            0b1101,
            0b1111
        };

        public static readonly HashSet<int> WallLeft = new HashSet<int>
        {
            0b1000
        };

        public static readonly HashSet<int> WallRight = new HashSet<int>
        {
            0b0010
        };

        public static readonly HashSet<int> WallBottom = new HashSet<int>
        {
            0b0100
        };

        public static readonly HashSet<int> WallFull = new HashSet<int>
        {
            0b0110,
            0b1010,
            0b1110
        };

        public static readonly HashSet<int> WallInnerCornerDownLeft = new HashSet<int>
        {
            0b00010001,
            0b00100001,
            0b00110001,
            0b01010001,
            0b01100001,
            0b01110001,
            0b10010000,
            0b10010001,
            0b10100000,
            0b10100001,
            0b10110000,
            0b10110001,
            0b11010000,
            0b11010001,
            0b11100000,
            0b11100001,
            0b11110000,
            0b11110001
        };

        public static readonly HashSet<int> WallInnerCornerDownRight = new HashSet<int>
        {
            0b00100100,
            0b00101000,
            0b00101100,
            0b00110100,
            0b00111000,
            0b00111100,
            0b01000100,
            0b01001000,
            0b01001100,
            0b01010100,
            0b01011000,
            0b01011100,
            0b01100100,
            0b01101000,
            0b01101100,
            0b01110100,
            0b01111000,
            0b01111100
        };

        public static readonly HashSet<int> WallDiagonalCornerDownLeft = new HashSet<int>
        {
            0b01000000
        };

        public static readonly HashSet<int> WallDiagonalCornerDownRight = new HashSet<int>
        {
            0b00010000
        };

        public static readonly HashSet<int> WallDiagonalCornerUpLeft = new HashSet<int>
        {
            0b00000001,
            0b01000001
        };

        public static readonly HashSet<int> WallDiagonalCornerUpRight = new HashSet<int>
        {
            0b00000100,
            0b00010100
        };

        public static readonly HashSet<int> WallBottomEightDirections = new HashSet<int>
        {
            0b01010000
        };

        public static readonly HashSet<int> WallFullEightDirections = new HashSet<int>
        {
            0b00000101,
            0b00001001,
            0b00001101,
            0b00010101,
            0b00011001,
            0b00011101,
            0b00101101,
            0b00110101,
            0b00111001,
            0b00111101,
            0b01000101,
            0b01001001,
            0b01001101,
            0b01011001,
            0b01011101,
            0b01100101,
            0b01110101,
            0b01111001,
            0b01111101,
            0b10000100,
            0b10000101,
            0b10010100,
            0b10010101,
            0b10100101,
            0b11000100,
            0b11000101,
            0b11010100,
            0b11010101,
            0b11100100,
            0b11100101,
            0b11110100,
            0b11110101
        };
    }
}
