using Microsoft.EntityFrameworkCore;
using MusicShop.Models;

namespace MusicShop.Data;

public static class CatalogSeeder
{
    public static void Populate(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Title = "Гитары и бас-гитары", Summary = "Акустические, электрогитары, бас-гитары, классические" },
            new Genre { Id = 2, Title = "Клавишные и синтезаторы", Summary = "Цифровые пианино, синтезаторы, MIDI-клавиатуры, органы" },
            new Genre { Id = 3, Title = "Ударные инструменты", Summary = "Акустические и электронные барабаны, перкуссия, тарелки" },
            new Genre { Id = 4, Title = "Струнные инструменты", Summary = "Скрипки, виолончели, контрабасы, укулеле" },
            new Genre { Id = 5, Title = "Духовые инструменты", Summary = "Саксофоны, трубы, флейты, кларнеты, тромбоны" }
        );

        modelBuilder.Entity<Instrument>().HasData(
            new Instrument { Id = 1, Title = "Yamaha F310 Natural", Overview = "Классическая акустическая гитара для начинающих и любителей. Корпус из выдержанной ели и меранти, яркий открытый звук.", RetailPrice = 12900m, StockCount = 34, GenreId = 1, CoverUrl = "https://placehold.co/300x300/13111c/a855f7?text=Guitar", ListedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Instrument { Id = 2, Title = "Fender Player Stratocaster SSS", Overview = "Легендарная электрогитара с тремя синглами. Кленовый гриф, корпус из ольхи, современная C-образная шейка.", RetailPrice = 89000m, StockCount = 12, GenreId = 1, CoverUrl = "https://placehold.co/300x300/1e0a3c/c084fc?text=Stratocaster", ListedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Instrument { Id = 3, Title = "Roland RD-88 Stage Piano", Overview = "Профессиональное сценическое пианино с 88 взвешенными клавишами. Механика SuperNATURAL, 128 голосов полифонии.", RetailPrice = 149000m, StockCount = 6, GenreId = 2, CoverUrl = "https://placehold.co/300x300/0f0c29/818cf8?text=Piano", ListedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Instrument { Id = 4, Title = "Casio CT-S300 Casiotone", Overview = "Компактный синтезатор для обучения. 61 клавиша, 48 голосов полифонии, 400 тембров, встроенные ритмы.", RetailPrice = 8900m, StockCount = 55, GenreId = 2, CoverUrl = "https://placehold.co/300x300/1a0a2e/a78bfa?text=Casio", ListedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Instrument { Id = 5, Title = "Pearl Export EXX 5-Piece", Overview = "Профессиональная барабанная установка из 5 предметов. Корпуса из тополя и берёзы, хромированная фурнитура.", RetailPrice = 79000m, StockCount = 8, GenreId = 3, CoverUrl = "https://placehold.co/300x300/1c1917/d97706?text=Drums", ListedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Instrument { Id = 6, Title = "Cremona SV-175 Скрипка 4/4", Overview = "Студенческая скрипка полного размера из выдержанной ели и клёна. Поставляется в комплекте со смычком и футляром.", RetailPrice = 18500m, StockCount = 22, GenreId = 4, CoverUrl = "https://placehold.co/300x300/1c0a0a/f87171?text=Violin", ListedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Instrument { Id = 7, Title = "Yamaha YAS-280 Alto Saxophone", Overview = "Студенческий альт-саксофон из жёлтой латуни с лакировкой. Удобная эргономика клапанов, стабильный строй.", RetailPrice = 89000m, StockCount = 9, GenreId = 5, CoverUrl = "https://placehold.co/300x300/1a1200/fbbf24?text=Saxophone", ListedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Instrument { Id = 8, Title = "Korg Volca Bass Synthesizer", Overview = "Аналоговый бас-синтезатор с секвенсором на 16 шагов. 3 генератора, фильтр LFO, MIDI In, встроенный динамик.", RetailPrice = 14900m, StockCount = 18, GenreId = 2, CoverUrl = "https://placehold.co/300x300/0a0a1a/6366f1?text=Korg+Volca", ListedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );

        modelBuilder.Entity<InstrumentSpecs>().HasData(
            new InstrumentSpecs { Id = 1, InstrumentId = 1, Brand = "Yamaha", Origin = "Япония", MassKg = 1.9, SizeInfo = "Дредноут, мензура 650 мм", GuaranteeMonths = 12 },
            new InstrumentSpecs { Id = 2, InstrumentId = 2, Brand = "Fender", Origin = "Мексика", MassKg = 3.6, SizeInfo = "Корпус ольха, гриф клён 648 мм", GuaranteeMonths = 24 },
            new InstrumentSpecs { Id = 3, InstrumentId = 3, Brand = "Roland", Origin = "Япония", MassKg = 18.5, SizeInfo = "1375 × 302 × 139 мм", GuaranteeMonths = 24 },
            new InstrumentSpecs { Id = 4, InstrumentId = 4, Brand = "Casio", Origin = "Япония", MassKg = 3.3, SizeInfo = "905 × 258 × 73 мм", GuaranteeMonths = 12 },
            new InstrumentSpecs { Id = 5, InstrumentId = 5, Brand = "Pearl", Origin = "Тайвань", MassKg = 52.0, SizeInfo = "бочка 22\", томы 10\"/12\"/16\", малый 14\"", GuaranteeMonths = 36 },
            new InstrumentSpecs { Id = 6, InstrumentId = 6, Brand = "Cremona", Origin = "Чехия", MassKg = 0.42, SizeInfo = "4/4, дека ель, обечайки клён", GuaranteeMonths = 6 }
        );

        modelBuilder.Entity<Buyer>().HasData(
            new Buyer { Id = 1, FullName = "Дмитрий Волков", Email = "dmitry@example.com", Phone = "+7-999-876-54-32", DeliveryAddress = "Санкт-Петербург, Музыкальная ул., 7", JoinedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );
    }
}
