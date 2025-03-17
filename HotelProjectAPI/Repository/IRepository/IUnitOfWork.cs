using HotelProject.Repository.IRepository.IMaster;
using HotelProject.Repository.IRepository.IMaster.IGuestMaster;
using HotelProject.Repository.IRepository.IMaster.IRoomMaster;
using HotelProject.Repository.IRepository.IWithoutMaster;

namespace HotelProject.Repository.IRepository
{
    public interface IUnitOfWork
    {
      
        void SaveChangesAsync();
        ICurrency HmsCurrency { get; }
        IHmsRoomMaster HmsRoomMasterRepository { get; }
        ITransGroupMaster HmsTransGroupMasterRepository { get; }
        IHmsSegmentMaster HmsSegmentMasterRepository { get; }
        IHmsGuestMaster HmsGuestMasterRepository { get; }
        IHmsGuestTrans HmsGuestTranRepository { get; }
        IHmsGuestGroup HmsGuestGroupRepository { get; }
        IHmsGuestcategMaster HmsGuestcategMasterRepository { get; }
        IHmsRoomTypeMaster HmsRoomTypeMasterRepository { get; }
        IRoomBoyMaster HmsRoomBoyMasterRepository { get; }
        IRoomReservationMaster HmsRoomReservationMasterRepository { get; }
        IHmsPlanMaster HmsPlanMasterRepository { get; }
        IHmsNationalityMaster HmsNationalityMasterRepository { get; }
        IHmsModeMaster HmsModeMasterRepository { get; }
        IHmsGlGroupMaster HmsGLGroupMaserRepository { get; }
        IHmsFreqMaster HmsFreqMasterRepository { get; }
        IHmsFloorMaster HmsFloorMasterRepository { get; }   
        IHmsCityLedgerMaster HmsCityLedgerMasterRepository { get; }
        ITempGuestView TempGuestViewRepository { get; }
        ITempInHouseGst TempInHouseGstRepository { get; }
        IHmsOccupancy OccupanyRepository { get; }
        IDailySummary DailySummaryRepository { get; }
        IDailySummaryGroupMaster DailySummaryGroupMasterRepository { get; }
        IModeDescription ModeDescriptionRepository { get; }
        IRoomMate RoomMateRepository { get; }
        IRoomRepairHistory RoomRepairHistoryRepository { get; }
        INoShowRooms NoShowRoomRepository { get; }
        IGuestLedgerTemp GuestLedgerTempRepository { get; }
        ITransactionCode TransactionCodeRepository { get; }
        IGuestRates GuestRatesRepository { get; }
        IHmsReservationDetailsRepository HmsReservationDetailsRepository { get; }
        IDocMaster DocMasterRepository { get; }
        IRoomBlock RoomBlockRepository { get; }
     IRateTypeMaster RateTypeMasterRepository { get; }
    }
}
