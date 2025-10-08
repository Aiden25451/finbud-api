namespace FinbudApi.Dto.UserHistory;
using System.ComponentModel.DataAnnotations;

public class UserHistoryResponseDTO
{
    [Required]
    public List<int> UserHistory { get; set; } = new List<int>{1};
}