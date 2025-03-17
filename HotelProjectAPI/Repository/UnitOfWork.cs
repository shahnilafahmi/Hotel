using HotelProject.Data;
using HotelProject.Repository.IRepository;
using HotelProject.Repository.IRepository.IMaster;
using HotelProject.Repository.IRepository.IMaster.IGuestMaster;
using HotelProject.Repository.IRepository.IMaster.IRoomMaster;
using HotelProject.Repository.IRepository.IWithoutMaster;
using HotelProject.Repository.MasterRepository;
using HotelProject.Repository.MasterRepository.GuestMasterRepository;
using HotelProject.Repository.MasterRepository.RoomMasterRepository;
using HotelProject.Repository.WithoutMaster_Repositories;

namespace HotelProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        //public IHotelRepository HotelRepository { get; private set; }
        public IHmsRoomMaster HmsRoomMasterRepository { get; private set; }
        public ICurrency HmsCurrency  { get; private set; }
        public ITransGroupMaster HmsTransGroupMasterRepository { get; private set; }
        public IHmsSegmentMaster HmsSegmentMasterRepository { get; private set; }
       public  IHmsGuestMaster HmsGuestMasterRepository { get; private set; }
        public IHmsGuestTrans HmsGuestTranRepository { get; private set; }
        public IHmsGuestGroup HmsGuestGroupRepository { get; private set; }
        public IHmsGuestcategMaster HmsGuestcategMasterRepository { get; private set; }
       public IHmsRoomTypeMaster HmsRoomTypeMasterRepository { get; private set; }
        public IRoomBoyMaster HmsRoomBoyMasterRepository { get; private set; }
       public IRoomReservationMaster HmsRoomReservationMasterRepository { get; private set; }
       public  IHmsPlanMaster HmsPlanMasterRepository { get; private set; }
        public IHmsNationalityMaster HmsNationalityMasterRepository { get; private set; }
        public IHmsModeMaster HmsModeMasterRepository { get; private set; }
        public IHmsGlGroupMaster HmsGLGroupMaserRepository { get; private set; }
        public IHmsFreqMaster HmsFreqMasterRepository { get; private set; }
       public IHmsFloorMaster HmsFloorMasterRepository { get; private set; }
        public IHmsCityLedgerMaster HmsCityLedgerMasterRepository { get; private set; }
        public ITempGuestView TempGuestViewRepository { get; private set; }
        public ITempInHouseGst TempInHouseGstRepository { get; private set; }
        public IHmsOccupancy OccupanyRepository { get; private set; }
        public IDailySummary DailySummaryRepository { get; private set; }
        public IDailySummaryGroupMaster DailySummaryGroupMasterRepository { get; private set; }
       public  IModeDescription ModeDescriptionRepository { get; private set; }
        public IRoomMate RoomMateRepository { get; private set; }
       public IRoomRepairHistory RoomRepairHistoryRepository { get; private set; }
        public INoShowRooms NoShowRoomRepository { get; private set; }
        public IGuestLedgerTemp GuestLedgerTempRepository { get; private set; }
        public ITransactionCode TransactionCodeRepository { get; private set; }
        public IGuestRates GuestRatesRepository { get; private set; }
        public IHmsReservationDetailsRepository HmsReservationDetailsRepository { get; private set; }
        public IDocMaster DocMasterRepository { get; private set; }
        public IRoomBlock RoomBlockRepository { get; private set; }
        public IRateTypeMaster RateTypeMasterRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            HmsGuestGroupRepository=new HmsGuestGroupMasterRepository(context);
            HmsRoomMasterRepository =new HmsRoomMasterRepository(context);
            HmsTransGroupMasterRepository = new HmsTransGroupMasterRepository(context);
            HmsSegmentMasterRepository = new HmsSegmentMasterRepository(context);
            HmsGuestMasterRepository = new HmsGuestMasterRepository(context);
            HmsGuestTranRepository = new HmsGuesTranRepository(context);
            HmsGuestcategMasterRepository = new HmsGuestCategMasterRepository(context);
            HmsRoomTypeMasterRepository = new HmsRoomTypeMasterRepository(context);
            HmsRoomBoyMasterRepository = new HmsRoomBoyMasterRepository(context);
            HmsRoomReservationMasterRepository = new HmsReservationMasterRepository(context);
            HmsPlanMasterRepository = new HmsPlanMasterRepository(context);
            HmsNationalityMasterRepository=new HmsNationalityMasterRepository(context);
            HmsModeMasterRepository = new HmsModeMasterRepository(context);
            HmsGLGroupMaserRepository = new HmsGlGroupMasterRepository(context);
            HmsFreqMasterRepository = new HmsFreqMasterRepository(context);
            HmsFloorMasterRepository = new HmsFloorMasterRepository(context);
            HmsCityLedgerMasterRepository = new HmsCityLedgerRepository(context);
            TempGuestViewRepository = new TempGuestViewRepository(context);
            TempInHouseGstRepository = new TempInHouseGstRepository(context);
            OccupanyRepository = new HmsOccupancyRepository(context);
            DailySummaryRepository = new DailySummaryRepository(context);
            DailySummaryGroupMasterRepository = new DailySummaryGroupMasterRepository(context);
            ModeDescriptionRepository = new ModeDescriptionRepository(context);
            RoomMateRepository = new RoomMateRepository(context);
            RoomRepairHistoryRepository = new RoomRepairHistoryRepository(context);
            NoShowRoomRepository = new NoShowRoomsRepository(context);
            GuestLedgerTempRepository = new GuestLedgerTempRepository(context);
            TransactionCodeRepository = new TransactionCodeRepository(context);
            GuestRatesRepository = new GuestRatesRepository(context);
            HmsReservationDetailsRepository = new HmsReservationDetailsRepository(context);
            DocMasterRepository = new DocMasterRepository(context);
            RoomBlockRepository = new RoomBlockRepository(context);
            RateTypeMasterRepository = new RateTypeMasterRepository(context);
            HmsCurrency = new CurrencyRepository(context);
        }

       

        public void SaveChangesAsync()
        {
            context.SaveChanges();
        }
    }
}
