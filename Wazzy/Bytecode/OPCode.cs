﻿namespace Wazzy.Bytecode
{
    public enum OPCode : byte
    {
        End = 0x0B,

        // Control Instructions [blocktype ::= valtype:byte | typeindex:s33]
        Unreachable = 0x00,
        Nop = 0x01,
        Block = 0x02,                   // <= {blocktype, (instr)*, 0x0B}
        Loop = 0x03,                    // <= {blocktype, (instr)*, 0x0B}
        If = 0x04,                      // <= {blocktype, (instr)*, 0x05 ? <Else> : 0x0B}
        Else = 0x05,                    // <= {(instr)*, 0x0B}
        Branch = 0x0C,                  // <= {labelidx u32}
        BranchIf = 0x0D,                // <= {labelidx u32}
        BranchTable = 0x0E,                // <= {vec(labelidx u32), labelidx u32}
        Return = 0x0F,
        Call = 0x10,                    // <= {funcidx u32}
        CallIndirect = 0x11,            // <= {typeidx u32, 0x00}

        // Parametric Instructions
        Drop = 0x1A,
        Select = 0x1B,

        // Variable Instructions
        GetLocal = 0x20,                // <= {localidx u32}
        SetLocal = 0x21,                // <= {localidx u32}
        TeeLocal = 0x22,                // <= {localidx u32}
        GetGlobal = 0x23,               // <= {globalidx u32}
        SetGlobal = 0x24,               // <= {globalidx u32}

        // Memory Instructions
        LoadI32 = 0x28,                 // <= {align u32, offset u32}
        LoadI64 = 0x29,                 // <= {align u32, offset u32}
        LoadF32 = 0x2A,                 // <= {align u32, offset u32}
        LoadF64 = 0x2B,                 // <= {align u32, offset u32}
        LoadI32_8S = 0x2C,              // <= {align u32, offset u32}
        LoadI32_8U = 0x2D,              // <= {align u32, offset u32}
        LoadI32_16S = 0x2E,             // <= {align u32, offset u32}
        LoadI32_16U = 0x2F,             // <= {align u32, offset u32}
        LoadI64_8S = 0x30,              // <= {align u32, offset u32}
        LoadI64_8U = 0x31,              // <= {align u32, offset u32}
        LoadI64_16S = 0x32,             // <= {align u32, offset u32}
        LoadI64_16U = 0x33,             // <= {align u32, offset u32}
        LoadI64_32S = 0x34,             // <= {align u32, offset u32}
        LoadI64_32U = 0x35,             // <= {align u32, offset u32}
        StoreI32 = 0x36,                // <= {align u32, offset u32}
        StoreI64 = 0x37,                // <= {align u32, offset u32}
        StoreF32 = 0x38,                // <= {align u32, offset u32}
        StoreF64 = 0x39,                // <= {align u32, offset u32}
        StoreI32_8 = 0x3A,              // <= {align u32, offset u32}
        StoreI32_16 = 0x3B,             // <= {align u32, offset u32}
        StoreI64_8 = 0x3C,              // <= {align u32, offset u32}
        StoreI64_16 = 0x3D,             // <= {align u32, offset u32}
        StoreI64_32 = 0x3E,             // <= {align u32, offset u32}
        MemorySize = 0x3F,              // <= 0x00
        MemoryGrow = 0x40,              // <= 0x00

        // Numeric Instructions
        ConstantI32 = 0x41,             // <= {n u32}
        ConstantI64 = 0x42,             // <= {n u32}
        ConstantF32 = 0x43,             // <= {z float}
        ConstantF64 = 0x44,             // <= {z float}

        EqualZeroI32 = 0x45,
        EqualI32 = 0x46,
        NotEqualI32 = 0x47,
        LessThanI32_S = 0x48,
        LessThanI32_U = 0x49,
        GreaterThanI32_S = 0x4A,
        GreaterThanI32_U = 0x4B,
        LessThanOrZeroI32_S = 0x4C,
        LessThanOrEqualI32_U = 0x4D,
        GreaterThanOrEqualI32_S = 0x4E,
        GreaterThanOrEqualI32_U = 0x4F,
        EqualZeroI64 = 0x50,
        EqualI64 = 0x51,
        NotEqualI64 = 0x52,
        LessThanI64_S = 0x53,
        LessThanI64_U = 0x54,
        GreaterThanI64_S = 0x55,
        GreaterThanI64_U = 0x56,
        LessThanOrEqualI64_S = 0x57,
        LessThanOrEqualI64_U = 0x58,
        GreaterThanOrEqualI64_S = 0x59,
        GreaterThanOrEqualI64_U = 0x5A,
        EqualF32 = 0x5B,
        NotEqualF32 = 0x5C,
        LessThanF32 = 0x5D,
        GreaterThanF32 = 0x5E,
        LessThanOrEqualF32 = 0x5F,
        GreaterThanOrEqualF32 = 0x60,
        EqualF64 = 0x61,
        NotEqualF64 = 0x62,
        LessThanF64 = 0x63,
        GreaterThanF64 = 0x64,
        LessThanOrEqualF64 = 0x65,
        GreaterThanOrEqualF64 = 0x66,
        CountLeadingZeroesI32 = 0x67,
        CountTrailingZeroesI32 = 0x68,
        PopCountI32 = 0x69,
        AddI32 = 0x6A,
        SubtractI32 = 0x6B,
        MultiplyI32 = 0x6C,
        DivideI32_S = 0x6D,
        DivideI32_U = 0x6E,
        i32_rem_s = 0x6F,
        RemainderI32_U = 0x70,
        AndI32 = 0x71,
        OrI32 = 0x72,
        XorI32 = 0x73,
        ShiftLeftI32 = 0x74,
        ShiftRightI32_S = 0x75,
        ShiftRightI32_U = 0x76,
        i32_rotl = 0x77,
        i32_rotr = 0x78,
        i64_clz = 0x79,
        i64_ctz = 0x7A,
        i64_popcnt = 0x7B,
        AddI64 = 0x7C,
        SubtractI64 = 0x7D,
        i64_mul = 0x7E,
        DivideI64_S = 0x7F,
        DivideI64_U = 0x80,
        i64_rem_s = 0x81,
        i64_rem_u = 0x82,
        AndI64 = 0x83,
        OrI64 = 0x84,
        i64_xor = 0x85,
        ShiftLeftI64 = 0x86,
        i64_shr_s = 0x87,
        ShiftRightI64_U = 0x88,
        RotateLeftI64 = 0x89,
        i64_rotr = 0x8A,
        AbsoluteF32 = 0x8B,
        NegateF32 = 0x8C,
        CeilingF32 = 0x8D,
        FloorF32 = 0x8E,
        f32_trunc = 0x8F,
        f32_nearest = 0x90,
        SquareRootF32 = 0x91,
        AddF32 = 0x92,
        SubtractF32 = 0x93,
        MultiplyF32 = 0x94,
        DivideF32 = 0x95,
        f32_min = 0x96,
        f32_max = 0x97,
        f32_copysign = 0x98,
        f64_abs = 0x99,
        f64_neg = 0x9A,
        CeilingF64 = 0x9B,
        FloorF64 = 0x9C,
        f64_trunc = 0x9D,
        f64_nearest = 0x9E,
        f64_sqrt = 0x9F,
        AddF64 = 0xA0,
        SubtractF64 = 0xA1,
        f64_mul = 0xA2,
        f64_div = 0xA3,
        MinF64 = 0xA4,
        MaxF64 = 0xA5,
        f64_copysign = 0xA6,
        WrapI64IntoI32 = 0xA7,
        TruncateF32IntoI32_S = 0xA8,
        i32_trunc_f32_u = 0xA9,
        i32_trunc_f64_s = 0xAA,
        i32_trunc_f64_u = 0xAB,
        ExtendI32IntoI64_S = 0xAC,
        ExtendI32IntoI64_U = 0xAD,
        i64_trunc_f32_s = 0xAE,
        i64_trunc_f32_u = 0xAF,
        i64_trunc_f64_s = 0xB0,
        i64_trunc_f64_u = 0xB1,
        ConvertSignedI32IntoF32 = 0xB2,
        ConvertI32IntoF32_U = 0xB3,
        f32_convert_i64_s = 0xB4,
        f32_convert_i64_u = 0xB5,
        DemoteF64IntoF32 = 0xB6,
        f64_convert_i32_s = 0xB7,
        f64_convert_i32_u = 0xB8,
        f64_convert_i64_s = 0xB9,
        f64_convert_i64_u = 0xBA,
        PromoteF32IntoF64 = 0xBB,
        ReinterpretF32IntoI32 = 0xBC,
        i64_reinterpret_f64 = 0xBD,
        ReinterpretI32IntoF32 = 0xBE,
        ReinterpretI64IntoF32 = 0xBF,
        ExtendI32_8S = 0xC0,
        i32_extend16_s = 0xC1,
        i64_extend8_s = 0xC2,
        i64_extend16_s = 0xC3,
        i64_extend32_s = 0xC4
    }
}