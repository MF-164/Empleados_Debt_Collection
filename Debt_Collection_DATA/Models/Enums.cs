namespace Debt_Collection_DATA.Models
{
    // Hours vs contractor status 
    public enum ContractorHoursStatus
    {
        SentForApproval = 0,        // נשלח לאישור
        Approved = 1,               // אושר
        WaitingForMoreInfo = 2,     // ממתין לבירור נוסף
        RequestedHoursFromContractor = 3, // נשלח בקשת שעות מקבלן
        NoHoursThisMonth = 4,       // אין שעות החודש
        WithoutApproval = 5         // ללא אישור (option that appears in list)
    }

    // Invoice status 
    public enum InvoiceStatus
    {
        Sent = 0,   // נשלח
        Signed = 1  // נחתם
    }

    // Payment status 
    public enum PaymentStatus
    {
        Paid = 0,               // שולם
        PartiallyPaid = 1,      // שולם חלקית
        LegalProcess = 2,       // בהליך משפטי
        NotApproved = 3,        // ללא אישור
        ProofReceived = 4,      // התקבל אסמכתא
        PaidMore = 5,           // שולם ביתר
        PaidBanked = 6,         // שולם - נכנס לבנק
        WithoutProof = 7,       // ללא אסמכתא
        NoHours = 8,            // אין שעות
        PostDatedCheck = 9      // צ'ק דחוי
    }
}
