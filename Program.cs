namespace Abstract_factory
{

    public interface IIngredient
    {
        string Dough();
        string Sauce();
        string Cheese();
        string Vegetable();

    }
    public class NYPizzaIngredientFactory : IIngredient
    {
        public string Dough()
        {
            return "Thin dough";
        }
        public string Sauce()
        {
            return "sweet onion sauce";
        }
        public string Cheese()
        {
            return "mozzarella cheese";
        }
        public string Vegetable()
        {
            return "tomato";
        }
    }

    public class LAPizzaIngredientFactory : IIngredient
    {
        public string Dough()
        {
            return "Deep dough";
        }

        public string Sauce()
        {
            return "Tomato sauce";
        }

        public string Cheese()
        {
            return "Cheddar cheese";
        }

        public string Vegetable()
        {
            return "Olive";
        }
    }


    public abstract class Pizza
    {
        public IIngredient ingredient;
        public string name;

        public string dough;
        public string sause;
        public string cheese;
        public string vegetable;

        public abstract void Preparing();

        public void Bake()
        {
            Console.WriteLine("Your pizza is baking");
        }

        public void Cut()
        {
            Console.WriteLine("Your pizza is cut");
        }

        public void Box()
        {
            Console.WriteLine("Boxing pizza");

        }

    }

    public class CheesePizza : Pizza
    {

        IIngredient ingredient;

        public CheesePizza(IIngredient ingredient)
        {
            this.ingredient = ingredient;
        }
        public override void Preparing()
        {
            Console.WriteLine("Preparing cheese pizza " + name);
            dough = ingredient.Dough();
            Console.WriteLine("*" + dough);
            sause = ingredient.Sauce();
            Console.WriteLine("*" + sause);
            cheese = ingredient.Cheese();
            Console.WriteLine("*" + dough);
            vegetable = ingredient.Vegetable();
            Console.WriteLine("*" + vegetable);
            Console.WriteLine("Done preparing cheese pizza");
        }
    }

    public class GreekPizza : Pizza
    {
        IIngredient ingredient;

        public GreekPizza(IIngredient ingredient)
        {
            this.ingredient = ingredient;
        }
        public override void Preparing()
        {
            Console.WriteLine("Preparing greek pizza " + name);
            dough = ingredient.Dough();
            Console.WriteLine("*" + dough);
            sause = ingredient.Sauce();
            Console.WriteLine("*" + sause);
            cheese = ingredient.Cheese();
            Console.WriteLine("*" + dough);
            vegetable = ingredient.Vegetable();
            Console.WriteLine("*" + vegetable);
            Console.WriteLine("Done preparing greek pizza");
        }
    }

    public abstract class PizzaStore
    {
        public abstract Pizza OrderPizza(string type);
    }

    public class NYPizzaStore : PizzaStore
    {

        IIngredient ingredient = new NYPizzaIngredientFactory();

        public override Pizza OrderPizza(string type)
        {
            Pizza pizza;

            if (type == "Cheese")
                pizza = new CheesePizza(ingredient);
            else
                pizza = new GreekPizza(ingredient);


            Console.WriteLine("Preparing NY Style Sauce and Cheese Pizza");
            pizza.Preparing();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }

    }

    public class LAPizzaStore : PizzaStore
    {

        IIngredient ingredient = new LAPizzaIngredientFactory();

        public override Pizza OrderPizza(string type)
        {
            Pizza pizza;

            if (type == "Cheese")
                pizza = new CheesePizza(ingredient);
            else
                pizza = new GreekPizza(ingredient);


            Console.WriteLine("LA Style Deep Dish Cheese Pizza");
            pizza.Preparing();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            PizzaStore NYStore = new NYPizzaStore();
            PizzaStore ChicagoStore = new LAPizzaStore();

            NYStore.OrderPizza("Cheese");
            Console.WriteLine("___________");
            ChicagoStore.OrderPizza("Greek");

        }
    }
}