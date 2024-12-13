using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using FOV.Domain.Entities.IngredientAggregator;

namespace API.IntegrationTest.Data;
public class IngredientTypeFaker : Faker<IngredientType>
{
    public IngredientTypeFaker()
    {
        UseSeed(12);
    }
}
