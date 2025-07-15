using VendasMvcWeb.Models;
using VendasMvcWeb.Models.Enums;


namespace VendasMvcWeb.Data
{
    public class SeedingService
    {
        private VendasMvcWebContext _context;

        public SeedingService(VendasMvcWebContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; // DB has been seeded
            }
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Books");
            Department d4 = new Department(4, "Fashion");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com",new DateTime(1998, 4, 21), "1000.00", d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1995, 12, 31), "1500.00", d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1990, 1, 15), "2000.00", d3);
            Seller s4 = new Seller(4, "Ana White", "ana@gmail.com", new DateTime(1985, 6, 10), "2500.00", d4);  
            Seller s5 = new Seller(5, "John Black", "jhon@gmail.com", new DateTime(1992, 3, 5), "3000.00", d1); 
            Seller s6 = new Seller(6, "Alice Blue", "alice@gmail.com", new DateTime(1988, 11, 20), "3500.00", d2);
            
            SalesRecord r1 = new SalesRecord(1, new DateTime(2023, 01, 01), 11000.00, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2023, 01, 02), 8000.00, SaleStatus.Billed, s2);    
            SalesRecord r3 = new SalesRecord(3, new DateTime(2023, 01, 03), 5000.00, SaleStatus.Pending, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2023, 01, 04), 7000.00, SaleStatus.Canceled, s4);  
            SalesRecord r5 = new SalesRecord(5, new DateTime(2023, 01, 05), 6000.00, SaleStatus.Billed, s5);    
            SalesRecord r6 = new SalesRecord(6, new DateTime(2023, 01, 06), 9000.00, SaleStatus.Billed, s6);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2023, 01, 07), 12000.00, SaleStatus.Billed, s1);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2023, 01, 08), 15000.00, SaleStatus.Billed, s2);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2023, 01, 09), 13000.00, SaleStatus.Billed, s3);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2023, 01, 10), 14000.00, SaleStatus.Billed, s4);
            SalesRecord r11 = new SalesRecord(11, new DateTime(2023, 01, 11), 16000.00, SaleStatus.Billed, s5);
            SalesRecord r12 = new SalesRecord(12, new DateTime(2023, 01, 12), 17000.00, SaleStatus.Billed, s6);
            SalesRecord r13 = new SalesRecord(13, new DateTime(2023, 01, 13), 18000.00, SaleStatus.Billed, s1);
            SalesRecord r14 = new SalesRecord(14, new DateTime(2023, 01, 14), 19000.00, SaleStatus.Billed, s2);
            SalesRecord r15 = new SalesRecord(15, new DateTime(2023, 01, 15), 20000.00, SaleStatus.Billed, s3);
            SalesRecord r16 = new SalesRecord(16, new DateTime(2023, 01, 16), 21000.00, SaleStatus.Billed, s4);
            SalesRecord r17 = new SalesRecord(17, new DateTime(2023, 01, 17), 22000.00, SaleStatus.Billed, s5);
            SalesRecord r18 = new SalesRecord(18, new DateTime(2023, 01, 18), 23000.00, SaleStatus.Billed, s6);
            SalesRecord r19 = new SalesRecord(19, new DateTime(2023, 01, 19), 24000.00, SaleStatus.Billed, s1);
            SalesRecord r20 = new SalesRecord(20, new DateTime(2023, 01, 20), 25000.00, SaleStatus.Billed, s2);
            SalesRecord r21 = new SalesRecord(21, new DateTime(2023, 01, 21), 26000.00, SaleStatus.Billed, s3);
            SalesRecord r22 = new SalesRecord(22, new DateTime(2023, 01, 22), 27000.00, SaleStatus.Billed, s4);
            SalesRecord r23 = new SalesRecord(23, new DateTime(2023, 01, 23), 28000.00, SaleStatus.Billed, s5);
            SalesRecord r24 = new SalesRecord(24, new DateTime(2023, 01, 24), 29000.00, SaleStatus.Billed, s6);
            SalesRecord r25 = new SalesRecord(25, new DateTime(2023, 01, 25), 30000.00, SaleStatus.Billed, s1);
            SalesRecord r26 = new SalesRecord(26, new DateTime(2023, 01, 26), 31000.00, SaleStatus.Billed, s2);
            SalesRecord r27 = new SalesRecord(27, new DateTime(2023, 01, 27), 32000.00, SaleStatus.Billed, s3);
            SalesRecord r28 = new SalesRecord(28, new DateTime(2023, 01, 28), 33000.00, SaleStatus.Billed, s4);
            SalesRecord r29 = new SalesRecord(29, new DateTime(2023, 01, 29), 34000.00, SaleStatus.Billed, s5);
            SalesRecord r30 = new SalesRecord(30, new DateTime(2023, 01, 30), 35000.00, SaleStatus.Billed, s6);
        
            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, 
                                           r7, r8, r9, r10, r11, r12,
                                           r13, r14, r15, r16, r17, r18,
                                           r19, r20, r21, r22, r23, r24,
                                           r25, r26, r27, r28, r29, r30);
            _context.SaveChanges();
        }
    } 
}
