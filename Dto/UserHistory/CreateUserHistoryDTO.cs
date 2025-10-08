namespace FinbudApi.Dto.UserHistory;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class CreateUserHistoryDTO
{
    [Required]
    public List<int> UserHistory { get; set; } = new List<int>{1};
}