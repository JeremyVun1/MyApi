using SQLite;

namespace MyApi.Models;

[Table("Counter")]
public class Counter
{
    [PrimaryKey, AutoIncrement]
    [Column("Id")]
    public int Id { get; set; } = 1;

    [Column("Value")]
    public int Value { get; set; } = 1;
}