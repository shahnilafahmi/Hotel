

using HotelProject.Models;
using HotelProject.Models.Models;
using HotelProject.Models.Models.Reservation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }

        public virtual DbSet<HmsCityledgerMaster> HmsCityledgerMasters { get; set; }
        public virtual DbSet<HmsCurrency> HmsCurrency { get; set; }
        public virtual DbSet<Source> Sources { get; set; }
        public virtual DbSet<Purpose> Purposes { get; set; }
        public virtual DbSet<MealPlan> MealPlans { get; set; }
        public virtual DbSet<AgentMaster> AgentMasters { get; set; }
        public virtual DbSet<BookingSource> BookingSources { get; set; }
        public virtual DbSet<SalesMan> SalesMen { get; set; }
        public virtual DbSet<HmsRateTypeMaster> HmsRateTypeMasters { get; set; }

        public virtual DbSet<HmsFloorMaster> HmsFloorMasters { get; set; }

        public virtual DbSet<HmsFreqMaster> HmsFreqMasters { get; set; }

        public virtual DbSet<HmsGlGroupMaster> HmsGlGroupMasters { get; set; }

        public virtual DbSet<HmsGuestCategMaster> HmsGuestCategMasters { get; set; }

        public virtual DbSet<HmsGuestGroupMaster> HmsGuestGroupMasters { get; set; }

        public virtual DbSet<HmsGuestMaster> HmsGuestMasters { get; set; }

        public virtual DbSet<HmsGuestRateTable> HmsGuestRateTables { get; set; }

        public virtual DbSet<HmsGuestTran> HmsGuestTrans { get; set; }

        public virtual DbSet<HmsModeMaster> HmsModeMasters { get; set; }

        public virtual DbSet<HmsNationalityMaster> HmsNationalityMasters { get; set; }

        public virtual DbSet<HmsOccupancy> HmsOccupancies { get; set; }

        public virtual DbSet<HmsPlanMaster> HmsPlanMasters { get; set; }

        public virtual DbSet<HmsRateTable> HmsRateTables { get; set; }

        public virtual DbSet<HmsReservationDetail> HmsReservationDetails { get; set; }

        public virtual DbSet<HmsReservationMaster> HmsReservationMasters { get; set; }

        public virtual DbSet<HmsReservationStatus> HmsReservationStatuses { get; set; }

        public virtual DbSet<HmsRoomBoyMaster> HmsRoomBoyMasters { get; set; }

        public virtual DbSet<HmsRoomMaster> HmsRoomMasters { get; set; }

        public virtual DbSet<HmsRoomMate> HmsRoomMates { get; set; }

        public virtual DbSet<HmsRoomRepairHistory> HmsRoomRepairHistories { get; set; }

        public virtual DbSet<HmsRoomTypeMaster> HmsRoomTypeMasters { get; set; }

        public virtual DbSet<HmsSegmentMaster> HmsSegmentMasters { get; set; }

        public virtual DbSet<HmsTransgroupMaster> HmsTransgroupMasters { get; set; }

        public virtual DbSet<HmsVisitPupose> HmsVisitPuposes { get; set; }

        public virtual DbSet<TempGuestView> TempGuestView { get; set; }
        public virtual DbSet<TempInhouseGST> TempInhouseGST { get; set; }
        public virtual DbSet<HmsDailySummary> HmsDailySummary { get; set; }
        public virtual DbSet<HmsOccupancy> HmsOccupancy { get; set; }

        public virtual DbSet<HmsDailySummaryGroupMaaster> HmsDailySummaryGroupMaasters { get; set; }

        public virtual DbSet<HmsGuestLedgerTemp> HmsGuestLedgerTemps { get; set; }

        public virtual DbSet<HmsNightAuditReport> HmsNightAuditReports { get; set; }

        public virtual DbSet<HmsNoshowRoom> HmsNoshowRooms { get; set; }

        public virtual DbSet<HmsTransactionCode> HmsTransactionCodes { get; set; }

        public virtual DbSet<HmsDocMaster> HmsDocMasters { get; set; }

        public virtual DbSet<HmsRoomBlockRoom> HmsRoomBlockRooms { get; set; }
  

        public virtual DbSet<HmsModeDescription> HmsModeDescriptions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TempGuestView>()
           .ToTable("Hms_TempGuestView");
            ////////////////////////
            modelBuilder.Entity<HmsRoomMaster>()
           .ToTable("Hms_Room_Master");
            ////////////////////////
            modelBuilder.Entity<HmsRoomTypeMaster>()
          .ToTable("Hms_RoomType_Master");
            ///////////////////////
            modelBuilder.Entity<HmsGuestCategMaster>()
          .ToTable("Hms_Guest_Categ_Master");
            modelBuilder.Entity<HmsReservationStatus>()
        .ToTable("Hms_Reservation_status");
           


            modelBuilder.Entity<HmsNationalityMaster>()
        .ToTable("Hms_Nationality_Master");
            ////////////////
            modelBuilder.Entity<HmsPlanMaster>()
         .ToTable("Hms_Plan_Master");
            //////////////////////
            modelBuilder.Entity<TempInhouseGST>()
           .ToTable("Hms_TempInhouseGST");
            //////////////////////
            modelBuilder.Entity<HmsGuestRateTable>()
          .ToTable("Hms_Guest_Rate_Table");
            //////////////////////
            modelBuilder.Entity<HmsReservationDetail>()
             .ToTable("Hms_Reservation_details");
            //////////////////////
            modelBuilder.Entity<HmsReservationMaster>()
         .ToTable("Hms_Reservation_Master");
            //////////////////////
            modelBuilder.Entity<HmsFloorMaster>()
         .ToTable("Hms_Floor_Master");
            //////////////////////
            modelBuilder.Entity<HmsFreqMaster>()
         .ToTable("Hms_Freq_Master");
            //////////////////////
            modelBuilder.Entity<HmsRoomBoyMaster>()
        .ToTable("Hms_RoomBoy_Master");
            //////////////////////
            modelBuilder.Entity<HmsCityledgerMaster>()
        .ToTable("Hms_Cityledger_Master");
            modelBuilder.Entity<HmsCurrency>()
                .ToTable("HMS_Currency");

            
            //////////////////////
            modelBuilder.Entity<HmsModeMaster>()
        .ToTable("Hms_Mode_Master");
            modelBuilder.Entity<HmsGuestGroupMaster>()
          .ToTable("Hms_Guest_group_Master");
            modelBuilder.Entity<HmsGuestTran>()
          .ToTable("Hms_Guest_Trans");
            modelBuilder.Entity<HmsGuestMaster>()
          .ToTable("Hms_Guest_Master");
            modelBuilder.Entity<HmsTransgroupMaster>()
          .ToTable("Hms_Transgroup_master");

            modelBuilder.Entity<HmsGlGroupMaster>()
         .ToTable("Hms_Gl_Group_Master");

            modelBuilder.Entity<HmsSegmentMaster>()
           .ToTable("Hms_Segment_Master");

            modelBuilder.Entity<HmsRoomMaster>()
           .HasKey(r => r.Id);

            modelBuilder.Entity<HmsTransgroupMaster>()
           .HasKey(r => r.Id);

            modelBuilder.Entity<HmsTransgroupMaster>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();
            // Optionally, you can specify that Id is an identity column as well
            modelBuilder.Entity<HmsRoomMaster>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd(); // T


            modelBuilder.Entity<HmsSegmentMaster>()
          .HasKey(r => r.SegmentId);
            modelBuilder.Entity<HmsSegmentMaster>()
                .Property(r => r.SegmentId)
                .ValueGeneratedOnAdd();
            /////////////////////////////
            modelBuilder.Entity<HmsModeDescription>()
          .HasKey(r => r.ModeId);
            modelBuilder.Entity<HmsModeDescription>()
                .Property(r => r.ModeId)
                .ValueGeneratedOnAdd();
            /////////////////////////////
            modelBuilder.Entity<HmsRoomTypeMaster>()
          .HasKey(r => r.RoomType_Id);
            modelBuilder.Entity<HmsRoomTypeMaster>()
                .Property(r => r.RoomType_Id)
                .ValueGeneratedOnAdd();
            /////////////////////////////
            modelBuilder.Entity<HmsFreqMaster>()
         .HasKey(r => r.Freq_Id);
            modelBuilder.Entity<HmsFreqMaster>()
                .Property(r => r.Freq_Id)
                .ValueGeneratedOnAdd();
            /////////////////////////////
            modelBuilder.Entity<HmsCityledgerMaster>()
         .HasKey(r => r.City_id);
            modelBuilder.Entity<HmsCityledgerMaster>()
                .Property(r => r.City_id)
                .ValueGeneratedOnAdd();
            /////////////////////////////
            modelBuilder.Entity<HmsGlGroupMaster>()
         .HasKey(r => r.GL_Group_Id);
            modelBuilder.Entity<HmsGlGroupMaster>()
                .Property(r => r.GL_Group_Id)
                .ValueGeneratedOnAdd();
            /////////////////////////////
            modelBuilder.Entity<HmsGuestMaster>()
        .HasKey(r => r.Guestid);
            modelBuilder.Entity<HmsGuestMaster>()
                .Property(r => r.Guestid)
                .ValueGeneratedOnAdd();
            /////////////////////////////

            modelBuilder.Entity<HmsGuestTran>()
        .HasKey(r => r.Id);
            modelBuilder.Entity<HmsGuestTran>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();
            /////////////////////////////

            modelBuilder.Entity<HmsModeMaster>()
        .HasKey(r => r.Mode_ID);
            modelBuilder.Entity<HmsModeMaster>()
                .Property(r => r.Mode_ID)
                .ValueGeneratedOnAdd();
            /////////////////////////////////
            modelBuilder.Entity<HmsGuestGroupMaster>()
    .HasKey(r => r.Group_id);
            modelBuilder.Entity<HmsGuestGroupMaster>()
                .Property(r => r.Group_id)
                .ValueGeneratedOnAdd();
            /////////////////////////////////////////////
            modelBuilder.Entity<HmsRoomRepairHistory>()
   .HasKey(r => r.Id);
            modelBuilder.Entity<HmsRoomRepairHistory>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();
            /////////////////////////////////////////////

            modelBuilder.Entity<HmsRoomBoyMaster>()
.HasKey(r => r.RoomBoy_id);
            modelBuilder.Entity<HmsRoomBoyMaster>()
                .Property(r => r.RoomBoy_id)
                .ValueGeneratedOnAdd();
            /////////////////////////////////////////////
            modelBuilder.Entity<HmsGuestCategMaster>()
   .HasKey(r => r.Guest_Categ_Id);
            modelBuilder.Entity<HmsGuestCategMaster>()
                .Property(r => r.Guest_Categ_Id)
                .ValueGeneratedOnAdd();
            /////////////////////////////////////////////
            modelBuilder.Entity<HmsReservationMaster>()
   .HasKey(r => r.Res_Id);
            modelBuilder.Entity<HmsReservationMaster>()
                .Property(r => r.Res_Id)
                .ValueGeneratedOnAdd();
            /////////////////////////////////////////////
            modelBuilder.Entity<HmsPlanMaster>()
   .HasKey(r => r.Planid);
            modelBuilder.Entity<HmsPlanMaster>()
                .Property(r => r.Planid)
                .ValueGeneratedOnAdd();
            /////////////////////////////////////////////
            modelBuilder.Entity<HmsFloorMaster>()
   .HasKey(r => r.Floorid);
            modelBuilder.Entity<HmsFloorMaster>()
                .Property(r => r.Floorid)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<HmsNationalityMaster>()
 .HasKey(r => r.Nat_id);
            modelBuilder.Entity<HmsNationalityMaster>()
                .Property(r => r.Nat_id)
                .ValueGeneratedOnAdd();
            ///////////////////////////////////
            modelBuilder.Entity<HmsReservationMaster>()
        .HasOne(r => r.RoomTypeMaster)
        .WithMany()
        .HasForeignKey(r => r.RoomTypeId)
        .IsRequired(false);  // Make it optional

            modelBuilder.Entity<HmsReservationMaster>()
                .HasOne(r => r.CityLedgerMaster)
                .WithMany()
                .HasForeignKey(r => r.CityLedger_Id)
                .IsRequired(false);  // Make it optional

            modelBuilder.Entity<HmsReservationMaster>()
                .HasOne(r => r.BookingSource)
                .WithMany()
                .HasForeignKey(r => r.BookingSource_id)
                .IsRequired(false);  // Make it optional

            modelBuilder.Entity<HmsReservationMaster>()
                .HasOne(r => r.AgentMaster)
                .WithMany()
                .HasForeignKey(r => r.AgentId)
                .IsRequired(false);  // Make it optional

            modelBuilder.Entity<HmsReservationMaster>()
                .HasOne(r => r.MealPlan)
                .WithMany()
                .HasForeignKey(r => r.MealPlanId)
                .IsRequired(false);  // Make it optional

            modelBuilder.Entity<HmsReservationMaster>()
                .HasOne(r => r.ReservationStatus)
                .WithMany()
                .HasForeignKey(r => r.Res_Status)
                .IsRequired(false);  // Make it optional

            modelBuilder.Entity<HmsReservationMaster>()
                .HasOne(r => r.SegmentMaster)
                .WithMany()
                .HasForeignKey(r => r.Segment_id)
                .IsRequired(false);  // Make it optional

            modelBuilder.Entity<HmsReservationMaster>()
                .HasOne(r => r.Sources)
                .WithMany()
                .HasForeignKey(r => r.Source)
                .IsRequired(false);  // Make it optional

            modelBuilder.Entity<HmsReservationMaster>()
                .HasOne(r => r.NationalityMaster)
                .WithMany()
                .HasForeignKey(r => r.Nat_id)
                .IsRequired(false);  // Make it optional

            modelBuilder.Entity<HmsReservationMaster>()
                .HasOne(r => r.SalesMan)
                .WithMany()
                .HasForeignKey(r => r.Sales_Person)
                .IsRequired(false);  // Make it optional

            modelBuilder.Entity<HmsReservationMaster>()
                .HasOne(r => r.GuestGroupMaster)
                .WithMany()
                .HasForeignKey(r => r.GroupId)
                .IsRequired(false);

        }
      
       
    }
}
