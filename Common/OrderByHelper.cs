using XxsModel;
using System; 
using System.Linq.Expressions; 
namespace Common
{


    public class OrderByHelper<TEntity>  where TEntity : XxsEntity
    {

        public OrderByType OrderByType { get; set; }
        private LambdaExpression  Expression;
        
        public void SetExpression<TProp>(Expression<Func<TEntity, TProp>> expression) 
        {
            this.Expression = expression;
        }

        public dynamic GetExpression()
        {
            return this.Expression;
        }

        public OrderByHelper()
        {

        }

    }

    public class OrderByHelper<TEntity, T> where TEntity : XxsEntity
    {
        public OrderByType OrderByType { get; set; }
        public Expression<Func<TEntity, T>> Expression { get; set; }
    }


}
