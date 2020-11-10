namespace Wazzy.Bytecode
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
        Load332_8U = 0x2D,              // <= {align u32, offset u32}
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

        EqualsZeroI32 = 0x45,
        EqualsI32 = 0x46,
        NotEqualI32 = 0x47,
        LessThanI32_S = 0x48,
        LessThanI32_U = 0x49,
        GreaterThanI32_S = 0x4A,
        GreaterThanI32_U = 0x4B,
        LessThanOrZeroI32_S = 0x4C,
        LessThanOrEqualI32_U = 0x4D,
        GreaterThanOrEqualI32_S = 0x4E,
        GreaterThanOrEqualI32_U = 0x4F,
        i64_eqz = 0x50,
        i64_eq = 0x51,
        i64_ne = 0x52,
        i64_lt_s = 0x53,
        i64_lt_u = 0x54,
        i64_gt_s = 0x55,
        i64_gt_u = 0x56,
        i64_le_s = 0x57,
        i64_le_u = 0x58,
        i64_ge_s = 0x59,
        i64_ge_u = 0x5A,
        EqualsF32 = 0x5B,
        NotEqualF32 = 0x5C,
        LessThanF32 = 0x5D,
        GreaterThanF32 = 0x5E,
        f32_le = 0x5F,
        GreaterThanOrEqualF32 = 0x60,
        f64_eq = 0x61,
        f64_ne = 0x62,
        LessThanF64 = 0x63,
        f64_gt = 0x64,
        f64_le = 0x65,
        f64_ge = 0x66,
        i32_clz = 0x67,
        i32_ctz = 0x68,
        i32_popcnt = 0x69,
        AddI32 = 0x6A,
        SubtractI32 = 0x6B,
        MultiplyI32 = 0x6C,
        DivideSignedI32 = 0x6D,
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
        DivideUnsignedI64 = 0x80,
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
        f32_neg = 0x8C,
        CeilingF32 = 0x8D,
        f32_floor = 0x8E,
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
        f64_ceil = 0x9B,
        f64_floor = 0x9C,
        f64_trunc = 0x9D,
        f64_nearest = 0x9E,
        f64_sqrt = 0x9F,
        f64_add = 0xA0,
        f64_sub = 0xA1,
        f64_mul = 0xA2,
        f64_div = 0xA3,
        f64_min = 0xA4,
        f64_max = 0xA5,
        f64_copysign = 0xA6,
        WrapI64IntoI32 = 0xA7,
        i32_trunc_f32_s = 0xA8,
        i32_trunc_f32_u = 0xA9,
        i32_trunc_f64_s = 0xAA,
        i32_trunc_f64_u = 0xAB,
        ExtendSignedI32IntoI64 = 0xAC,
        ExtendUnsignedI32IntoI64 = 0xAD,
        i64_trunc_f32_s = 0xAE,
        i64_trunc_f32_u = 0xAF,
        i64_trunc_f64_s = 0xB0,
        i64_trunc_f64_u = 0xB1,
        ConvertSignedI32IntoF32 = 0xB2,
        f32_convert_i32_u = 0xB3,
        f32_convert_i64_s = 0xB4,
        f32_convert_i64_u = 0xB5,
        f32_demote_f64 = 0xB6,
        f64_convert_i32_s = 0xB7,
        f64_convert_i32_u = 0xB8,
        f64_convert_i64_s = 0xB9,
        f64_convert_i64_u = 0xBA,
        f64_promote_f32 = 0xBB,
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