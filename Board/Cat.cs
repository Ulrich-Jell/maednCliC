namespace maednCls.Board
{
    public class Cat     
{         
	private int health;         
	public string Name { get; set; }         
	public int Health         
	{             
		get => this.health;             
		set             
		{                 
			this.health = value;                 
			this.OnHealthChanged?.Invoke(this, this.health);             
		}         
	}
        
	public event EventHandler<int> OnHealthChanged; 
}
}