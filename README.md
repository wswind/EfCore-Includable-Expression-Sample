# EfCoreIncludeThenIncludeExpressionsParams
use efcore Include Theninclude for expression params
 
## learn form
https://stackoverflow.com/questions/42904414/multiple-includes-in-ef-core

## problems

the origin code would cause object cast error. 

```
var includable = ((Includable<TEntity, IEnumerable<TProperty>>)includes);

public class Model1
{
	public int Id { get; set; }
	public string DataModel1 { get; set; }
	//cause exception ,can't cast :  IIncludable<TEntity, List<TProperty>> ==>  Includable<TEntity, IEnumerable<TProperty>>
	public virtual List<Model2> Model2 {get;set;}
}
```

to fix it I changed the code.