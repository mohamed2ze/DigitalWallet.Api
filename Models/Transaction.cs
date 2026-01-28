using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWallet.Api.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int SenderWalletId { get; set; }
        public int ReceiverWalletId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;
    }
}
