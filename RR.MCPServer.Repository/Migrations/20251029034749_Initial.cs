using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RR.MCPServer.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Core");

            migrationBuilder.CreateTable(
                name: "Underwriter",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateDeactivated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Underwriter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    EffectiveDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ExpirationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IssueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CertificateNumber = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Carrier = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CarrierAddress = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    CarrierContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProducerAddress = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    ProducerEmail = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    InsuredName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    InsuredAddress = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    InsuredPhone = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateDeactivated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policy_Underwriter_CarrierContactId",
                        column: x => x.CarrierContactId,
                        principalSchema: "Core",
                        principalTable: "Underwriter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Underwriter",
                columns: new[] { "Id", "DateCreated", "DateDeactivated", "Email", "FirstName", "LastName", "Title" },
                values: new object[,]
                {
                    { new Guid("18dd538a-8c86-4e63-96aa-af4c6012b914"), new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "sarah.johnson@insurance.com", "Sarah", "Johnson", "Lead Underwriter" },
                    { new Guid("a3b5c7d9-1234-5678-90ab-cdef12345678"), new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "michael.williams@insurance.com", "Michael", "Williams", "Underwriter" },
                    { new Guid("a9b1c3d5-7890-1234-5601-345678901234"), new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "christopher.wilson@insurance.com", "Christopher", "Wilson", "Underwriter" },
                    { new Guid("b0c2d4e6-8901-2345-6712-456789012345"), new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "jennifer.taylor@insurance.com", "Jennifer", "Taylor", "Senior Underwriter" },
                    { new Guid("b4c6d8e0-2345-6789-01bc-def123456789"), new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "emily.brown@insurance.com", "Emily", "Brown", "Senior Underwriter" },
                    { new Guid("c5d7e9f1-3456-7890-12cd-ef1234567890"), new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "david.davis@insurance.com", "David", "Davis", "Chief Underwriter" },
                    { new Guid("d2ca3e40-dadd-44ba-8fcf-bbf92ec4ab3c"), new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "john.smith@insurance.com", "John", "Smith", "Senior Underwriter" },
                    { new Guid("d6e8f0a2-4567-8901-23de-f12345678901"), new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "jessica.martinez@insurance.com", "Jessica", "Martinez", "Underwriter" },
                    { new Guid("e7f9a1b3-5678-9012-34ef-123456789012"), new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "robert.garcia@insurance.com", "Robert", "Garcia", "Senior Underwriter" },
                    { new Guid("f8a0b2c4-6789-0123-45f0-234567890123"), new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "amanda.rodriguez@insurance.com", "Amanda", "Rodriguez", "Lead Underwriter" }
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Policy",
                columns: new[] { "Id", "Carrier", "CarrierAddress", "CarrierContactId", "CertificateNumber", "DateCreated", "DateDeactivated", "EffectiveDate", "ExpirationDate", "InsuredAddress", "InsuredName", "InsuredPhone", "IssueDate", "PolicyNumber", "Producer", "ProducerAddress", "ProducerEmail" },
                values: new object[,]
                {
                    { new Guid("0b1c2d3e-4f5a-6b7c-8d9e-0f1a2b3c4d5e"), "QBE Insurance", "55 Water St, New York, NY 10041", new Guid("b0c2d4e6-8901-2345-6712-456789012345"), "CERT-020-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 10, 15), new DateOnly(2026, 10, 15), "234 Tech Campus Dr, Redmond, WA 98052", "Evergreen Technology Corp", "(425) 555-0020", new DateOnly(2025, 10, 5), "POL-2025-020", "Pacific Northwest Insurance", "567 Pioneer Square, Seattle, WA 98104", "team@pacificnorthwestins.com" },
                    { new Guid("0d1e2f3a-4b5c-6d7e-8f9a-0b1c2d3e4f5a"), "AIG Insurance", "175 Water St, New York, NY 10038", new Guid("b0c2d4e6-8901-2345-6712-456789012345"), "CERT-010-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 5, 15), new DateOnly(2026, 5, 15), "987 Power Plant Rd, Minneapolis, MN 55403", "Northern Energy Systems", "(612) 555-0010", new DateOnly(2025, 5, 5), "POL-2025-010", "Pinnacle Risk Management", "678 Executive Park, Minneapolis, MN 55402", "risk@pinnaclemanagement.com" },
                    { new Guid("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Liberty Mutual Insurance", "175 Berkeley St, Boston, MA 02116", new Guid("d2ca3e40-dadd-44ba-8fcf-bbf92ec4ab3c"), "CERT-001-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 1, 1), new DateOnly(2026, 1, 1), "456 Business Blvd, New York, NY 10002", "Acme Corporation", "(212) 555-0001", new DateOnly(2024, 12, 15), "POL-2025-001", "ABC Insurance Agency", "123 Main St, Suite 100, New York, NY 10001", "contact@abcinsurance.com" },
                    { new Guid("1e2f3a4b-5c6d-7e8f-9a0b-1c2d3e4f5a6b"), "Zurich Insurance", "1299 Zurich Way, Schaumburg, IL 60196", new Guid("d2ca3e40-dadd-44ba-8fcf-bbf92ec4ab3c"), "CERT-011-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 6, 1), new DateOnly(2026, 6, 1), "543 Farm Rd, Des Moines, IA 50309", "Heartland Agriculture Co", "(515) 555-0011", new DateOnly(2025, 5, 20), "POL-2025-011", "Midwest Insurance Professionals", "234 Insurance Ln, Kansas City, MO 64105", "pros@midwestinsurance.com" },
                    { new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"), "State Farm Insurance", "One State Farm Plaza, Bloomington, IL 61710", new Guid("18dd538a-8c86-4e63-96aa-af4c6012b914"), "CERT-002-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 1, 15), new DateOnly(2026, 1, 15), "321 Technology Dr, San Francisco, CA 94102", "Global Tech Solutions", "(415) 555-0002", new DateOnly(2025, 1, 5), "POL-2025-002", "Smith & Associates Insurance", "789 Oak Ave, Chicago, IL 60601", "info@smithassociates.com" },
                    { new Guid("2f3a4b5c-6d7e-8f9a-0b1c-2d3e4f5a6b7c"), "CNA Insurance", "333 S Wabash Ave, Chicago, IL 60604", new Guid("18dd538a-8c86-4e63-96aa-af4c6012b914"), "CERT-012-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 6, 15), new DateOnly(2026, 6, 15), "876 Innovation Dr, San Jose, CA 95113", "West Coast Engineering LLC", "(408) 555-0012", new DateOnly(2025, 6, 5), "POL-2025-012", "Coastal Insurance Advisors", "765 Beach Blvd, San Diego, CA 92101", "advisors@coastalinsurance.com" },
                    { new Guid("3a4b5c6d-7e8f-9a0b-1c2d-3e4f5a6b7c8d"), "Berkshire Hathaway Insurance", "3024 Harney St, Omaha, NE 68131", new Guid("a3b5c7d9-1234-5678-90ab-cdef12345678"), "CERT-013-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 7, 1), new DateOnly(2026, 7, 1), "234 Parts Ave, Cleveland, OH 44113", "Reliable Auto Parts Inc", "(216) 555-0013", new DateOnly(2025, 6, 20), "POL-2025-013", "Central States Insurance", "432 Center St, Indianapolis, IN 46204", "central@statesinsurance.com" },
                    { new Guid("3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"), "Travelers Insurance", "485 Lexington Ave, New York, NY 10017", new Guid("a3b5c7d9-1234-5678-90ab-cdef12345678"), "CERT-003-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 2, 1), new DateOnly(2026, 2, 1), "678 Industrial Way, Detroit, MI 48201", "Metro Manufacturing Inc", "(313) 555-0003", new DateOnly(2025, 1, 20), "POL-2025-003", "Premier Insurance Group", "555 Market St, Philadelphia, PA 19103", "sales@premiergroup.com" },
                    { new Guid("4b5c6d7e-8f9a-0b1c-2d3e-4f5a6b7c8d9e"), "Kemper Insurance", "200 E Randolph St, Chicago, IL 60601", new Guid("b4c6d8e0-2345-6789-01bc-def123456789"), "CERT-014-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 7, 15), new DateOnly(2026, 7, 15), "789 Research Pkwy, Raleigh, NC 27601", "Eastern Pharmaceutical Corp", "(919) 555-0014", new DateOnly(2025, 7, 5), "POL-2025-014", "Atlantic Insurance Group", "567 Harbor View, Baltimore, MD 21201", "group@atlanticinsurance.com" },
                    { new Guid("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f9a"), "Nationwide Insurance", "1 Nationwide Plaza, Columbus, OH 43215", new Guid("b4c6d8e0-2345-6789-01bc-def123456789"), "CERT-004-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 2, 15), new DateOnly(2026, 2, 15), "890 Harbor Dr, Miami, FL 33101", "Coastal Shipping LLC", "(305) 555-0004", new DateOnly(2025, 2, 5), "POL-2025-004", "Johnson Insurance Services", "234 Elm St, Houston, TX 77002", "team@johnsoninsurance.com" },
                    { new Guid("5c6d7e8f-9a0b-1c2d-3e4f-5a6b7c8d9e0f"), "Markel Insurance", "4521 Highwoods Pkwy, Glen Allen, VA 23060", new Guid("c5d7e9f1-3456-7890-12cd-ef1234567890"), "CERT-015-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 8, 1), new DateOnly(2026, 8, 1), "321 Resort Blvd, Aspen, CO 81611", "Rocky Mountain Hospitality", "(970) 555-0015", new DateOnly(2025, 7, 20), "POL-2025-015", "Summit Insurance Partners", "890 Mountain View Dr, Salt Lake City, UT 84101", "partners@summitinsurance.com" },
                    { new Guid("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b"), "Allstate Insurance", "2775 Sanders Rd, Northbrook, IL 60062", new Guid("c5d7e9f1-3456-7890-12cd-ef1234567890"), "CERT-005-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 3, 1), new DateOnly(2026, 3, 1), "765 Medical Center Dr, Boston, MA 02115", "Summit Healthcare Group", "(617) 555-0005", new DateOnly(2025, 2, 20), "POL-2025-005", "Elite Risk Advisors", "432 Pine St, Seattle, WA 98101", "advisors@eliterisk.com" },
                    { new Guid("6d7e8f9a-0b1c-2d3e-4f5a-6b7c8d9e0f1a"), "MetLife Insurance", "200 Park Ave, New York, NY 10166", new Guid("d6e8f0a2-4567-8901-23de-f12345678901"), "CERT-016-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 8, 15), new DateOnly(2026, 8, 15), "456 Broadway, Nashville, TN 37203", "Music City Entertainment LLC", "(615) 555-0016", new DateOnly(2025, 8, 5), "POL-2025-016", "Professional Risk Solutions", "123 Corporate Dr, Nashville, TN 37203", "solutions@professionalrisk.com" },
                    { new Guid("6f7a8b9c-0d1e-2f3a-4b5c-6d7e8f9a0b1c"), "Progressive Insurance", "6300 Wilson Mills Rd, Mayfield Village, OH 44143", new Guid("d6e8f0a2-4567-8901-23de-f12345678901"), "CERT-006-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 3, 15), new DateOnly(2026, 3, 15), "234 Builder Ln, Phoenix, AZ 85001", "Mountain Construction Co", "(602) 555-0006", new DateOnly(2025, 3, 5), "POL-2025-006", "Guardian Insurance Partners", "567 Broadway, Denver, CO 80202", "info@guardianpartners.com" },
                    { new Guid("7a8b9c0d-1e2f-3a4b-5c6d-7e8f9a0b1c2d"), "Chubb Insurance", "202 Hall's Mill Rd, Whitehouse Station, NJ 08889", new Guid("e7f9a1b3-5678-9012-34ef-123456789012"), "CERT-007-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 4, 1), new DateOnly(2026, 4, 1), "543 Commerce St, Portland, OR 97201", "Pacific Retail Ventures", "(503) 555-0007", new DateOnly(2025, 3, 20), "POL-2025-007", "Capital Insurance Brokers", "890 Capitol Ave, Sacramento, CA 95814", "brokers@capitalinsurance.com" },
                    { new Guid("7e8f9a0b-1c2d-3e4f-5a6b-7c8d9e0f1a2b"), "Hanover Insurance", "440 Lincoln St, Worcester, MA 01653", new Guid("e7f9a1b3-5678-9012-34ef-123456789012"), "CERT-017-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 9, 1), new DateOnly(2026, 9, 1), "567 Wharf St, Portland, ME 04101", "New England Seafood Co", "(207) 555-0017", new DateOnly(2025, 8, 20), "POL-2025-017", "Northeast Insurance Specialists", "234 Main St, Portland, ME 04101", "specialists@northeastins.com" },
                    { new Guid("8b9c0d1e-2f3a-4b5c-6d7e-8f9a0b1c2d3e"), "Hartford Insurance", "One Hartford Plaza, Hartford, CT 06155", new Guid("f8a0b2c4-6789-0123-45f0-234567890123"), "CERT-008-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 4, 15), new DateOnly(2026, 4, 15), "876 Transport Way, Dallas, TX 75201", "Midland Logistics Group", "(214) 555-0008", new DateOnly(2025, 4, 5), "POL-2025-008", "Advantage Insurance Solutions", "123 Financial Dr, Charlotte, NC 28202", "solutions@advantageins.com" },
                    { new Guid("8f9a0b1c-2d3e-4f5a-6b7c-8d9e0f1a2b3c"), "AmTrust Insurance", "59 Maiden Ln, New York, NY 10038", new Guid("f8a0b2c4-6789-0123-45f0-234567890123"), "CERT-018-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 9, 15), new DateOnly(2026, 9, 15), "321 Solar Way, Tucson, AZ 85701", "Desert Solar Solutions", "(520) 555-0018", new DateOnly(2025, 9, 5), "POL-2025-018", "Southwest Risk Advisors", "789 Desert Vista, Albuquerque, NM 87102", "advisors@southwestrisk.com" },
                    { new Guid("9a0b1c2d-3e4f-5a6b-7c8d-9e0f1a2b3c4d"), "Selective Insurance", "40 Wantage Ave, Branchville, NJ 07890", new Guid("a9b1c3d5-7890-1234-5601-345678901234"), "CERT-019-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 10, 1), new DateOnly(2026, 10, 1), "876 Brewery Ave, Milwaukee, WI 53202", "Wisconsin Brewing Company", "(414) 555-0019", new DateOnly(2025, 9, 20), "POL-2025-019", "Great Lakes Insurance Brokers", "432 Lake Shore Dr, Milwaukee, WI 53202", "brokers@greatlakesins.com" },
                    { new Guid("9c0d1e2f-3a4b-5c6d-7e8f-9a0b1c2d3e4f"), "Farmers Insurance", "4680 Wilshire Blvd, Los Angeles, CA 90010", new Guid("a9b1c3d5-7890-1234-5601-345678901234"), "CERT-009-2025", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new DateOnly(2025, 5, 1), new DateOnly(2026, 5, 1), "432 Culinary Ct, New Orleans, LA 70112", "Southern Food Services Inc", "(504) 555-0009", new DateOnly(2025, 4, 20), "POL-2025-009", "Heritage Insurance Agency", "345 Heritage Blvd, Atlanta, GA 30303", "agency@heritageins.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Policy_CarrierContactId",
                schema: "Core",
                table: "Policy",
                column: "CarrierContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policy",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Underwriter",
                schema: "Core");
        }
    }
}
