using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814

namespace MusicShop.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    DeliveryAddress = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    JoinedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Summary = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlacedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShipTo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    BuyerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Overview = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockCount = table.Column<int>(type: "integer", nullable: false),
                    CoverUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ListedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instruments_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BasketEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Qty = table.Column<int>(type: "integer", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BuyerId = table.Column<int>(type: "integer", nullable: false),
                    InstrumentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketEntries_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketEntries_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentSpecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Origin = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MassKg = table.Column<double>(type: "double precision", nullable: true),
                    SizeInfo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    GuaranteeMonths = table.Column<int>(type: "integer", nullable: false),
                    InstrumentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentSpecs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentSpecs_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Qty = table.Column<int>(type: "integer", nullable: false),
                    PriceAtSale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseId = table.Column<int>(type: "integer", nullable: false),
                    InstrumentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseEntries_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseEntries_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Seed data
            migrationBuilder.Sql(@"INSERT INTO ""Genres"" (""Id"", ""Title"", ""Summary"") VALUES
(1, 'Гитары и бас-гитары', 'Акустические, электрогитары, бас-гитары, классические'),
(2, 'Клавишные и синтезаторы', 'Цифровые пианино, синтезаторы, MIDI-клавиатуры, органы'),
(3, 'Ударные инструменты', 'Акустические и электронные барабаны, перкуссия, тарелки'),
(4, 'Струнные инструменты', 'Скрипки, виолончели, контрабасы, укулеле'),
(5, 'Духовые инструменты', 'Саксофоны, трубы, флейты, кларнеты, тромбоны');");

            migrationBuilder.Sql(@"INSERT INTO ""Buyers"" (""Id"", ""FullName"", ""Email"", ""Phone"", ""DeliveryAddress"", ""JoinedAt"") VALUES
(1, 'Дмитрий Волков', 'dmitry@example.com', '+7-999-876-54-32', 'Санкт-Петербург, Музыкальная ул., 7', '2024-01-01T00:00:00Z');");

            migrationBuilder.Sql(@"INSERT INTO ""Instruments"" (""Id"", ""Title"", ""Overview"", ""RetailPrice"", ""StockCount"", ""GenreId"", ""CoverUrl"", ""ListedAt"") VALUES
(1, 'Yamaha F310 Natural', 'Классическая акустическая гитара для начинающих и любителей. Корпус из выдержанной ели и меранти, яркий открытый звук.', 12900.00, 34, 1, 'https://placehold.co/300x300/13111c/a855f7?text=Guitar', '2024-01-01T00:00:00Z'),
(2, 'Fender Player Stratocaster SSS', 'Легендарная электрогитара с тремя синглами. Кленовый гриф, корпус из ольхи, современная C-образная шейка.', 89000.00, 12, 1, 'https://placehold.co/300x300/1e0a3c/c084fc?text=Stratocaster', '2024-01-01T00:00:00Z'),
(3, 'Roland RD-88 Stage Piano', 'Профессиональное сценическое пианино с 88 взвешенными клавишами. Механика SuperNATURAL, 128 голосов полифонии.', 149000.00, 6, 2, 'https://placehold.co/300x300/0f0c29/818cf8?text=Piano', '2024-01-01T00:00:00Z'),
(4, 'Casio CT-S300 Casiotone', 'Компактный синтезатор для обучения. 61 клавиша, 48 голосов полифонии, 400 тембров, встроенные ритмы.', 8900.00, 55, 2, 'https://placehold.co/300x300/1a0a2e/a78bfa?text=Casio', '2024-01-01T00:00:00Z'),
(5, 'Pearl Export EXX 5-Piece', 'Профессиональная барабанная установка из 5 предметов. Корпуса из тополя и берёзы, хромированная фурнитура.', 79000.00, 8, 3, 'https://placehold.co/300x300/1c1917/d97706?text=Drums', '2024-01-01T00:00:00Z'),
(6, 'Cremona SV-175 Скрипка 4/4', 'Студенческая скрипка полного размера из выдержанной ели и клёна. Поставляется в комплекте со смычком и футляром.', 18500.00, 22, 4, 'https://placehold.co/300x300/1c0a0a/f87171?text=Violin', '2024-01-01T00:00:00Z'),
(7, 'Yamaha YAS-280 Alto Saxophone', 'Студенческий альт-саксофон из жёлтой латуни с лакировкой. Удобная эргономика клапанов, стабильный строй.', 89000.00, 9, 5, 'https://placehold.co/300x300/1a1200/fbbf24?text=Saxophone', '2024-01-01T00:00:00Z'),
(8, 'Korg Volca Bass Synthesizer', 'Аналоговый бас-синтезатор с секвенсором на 16 шагов. 3 генератора, фильтр LFO, MIDI In, встроенный динамик.', 14900.00, 18, 2, 'https://placehold.co/300x300/0a0a1a/6366f1?text=Korg+Volca', '2024-01-01T00:00:00Z');");

            migrationBuilder.Sql(@"INSERT INTO ""InstrumentSpecs"" (""Id"", ""InstrumentId"", ""Brand"", ""Origin"", ""MassKg"", ""SizeInfo"", ""GuaranteeMonths"") VALUES
(1, 1, 'Yamaha', 'Япония', 1.9, 'Дредноут, мензура 650 мм', 12),
(2, 2, 'Fender', 'Мексика', 3.6, 'Корпус ольха, гриф клён 648 мм', 24),
(3, 3, 'Roland', 'Япония', 18.5, '1375 × 302 × 139 мм', 24),
(4, 4, 'Casio', 'Япония', 3.3, '905 × 258 × 73 мм', 12),
(5, 5, 'Pearl', 'Тайвань', 52.0, 'бочка 22"", томы 10""/12""/16"", малый 14""', 36),
(6, 6, 'Cremona', 'Чехия', 0.42, '4/4, дека ель, обечайки клён', 6);");

            // Advance identity sequences past the seeded IDs
            migrationBuilder.Sql(@"
SELECT setval(pg_get_serial_sequence('""Buyers""', 'Id'), MAX(""Id"")) FROM ""Buyers"";
SELECT setval(pg_get_serial_sequence('""Genres""', 'Id'), MAX(""Id"")) FROM ""Genres"";
SELECT setval(pg_get_serial_sequence('""Instruments""', 'Id'), MAX(""Id"")) FROM ""Instruments"";
SELECT setval(pg_get_serial_sequence('""InstrumentSpecs""', 'Id'), MAX(""Id"")) FROM ""InstrumentSpecs"";
");

            // Indexes
            migrationBuilder.CreateIndex(name: "IX_BasketEntries_BuyerId", table: "BasketEntries", column: "BuyerId");
            migrationBuilder.CreateIndex(name: "IX_BasketEntries_InstrumentId", table: "BasketEntries", column: "InstrumentId");
            migrationBuilder.CreateIndex(name: "IX_Buyers_Email", table: "Buyers", column: "Email", unique: true);
            migrationBuilder.CreateIndex(name: "IX_Genres_Title", table: "Genres", column: "Title", unique: true);
            migrationBuilder.CreateIndex(name: "IX_Instruments_GenreId", table: "Instruments", column: "GenreId");
            migrationBuilder.CreateIndex(name: "IX_InstrumentSpecs_InstrumentId", table: "InstrumentSpecs", column: "InstrumentId", unique: true);
            migrationBuilder.CreateIndex(name: "IX_PurchaseEntries_InstrumentId", table: "PurchaseEntries", column: "InstrumentId");
            migrationBuilder.CreateIndex(name: "IX_PurchaseEntries_PurchaseId", table: "PurchaseEntries", column: "PurchaseId");
            migrationBuilder.CreateIndex(name: "IX_Purchases_BuyerId", table: "Purchases", column: "BuyerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "BasketEntries");
            migrationBuilder.DropTable(name: "InstrumentSpecs");
            migrationBuilder.DropTable(name: "PurchaseEntries");
            migrationBuilder.DropTable(name: "Purchases");
            migrationBuilder.DropTable(name: "Instruments");
            migrationBuilder.DropTable(name: "Genres");
            migrationBuilder.DropTable(name: "Buyers");
        }
    }
}
