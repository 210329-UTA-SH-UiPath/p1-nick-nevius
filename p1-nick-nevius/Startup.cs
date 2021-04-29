using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonSubTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace p1_nick_nevius
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers();

			// lol no
			//services.AddDbContext<PizzaBox.Storing.Entities.PizzaBoxDbContext>(options =>
			//options.UseSqlServer("Server=tcp:pizzaboxapp-nick.database.windows.net,1433;Initial Catalog=PizzaBoxDB-Nick;User ID=dev;Password=<password>")
			//);
			services.AddDbContext<PizzaBox.Storing.Entities.PizzaBoxDbContext>();
			services.AddScoped<IRepository<ACrust>, CrustRepository>();
			services.AddScoped<IRepository<Customer>, CustomerRepository>();
			services.AddScoped<IRepository<Order>, OrderRepository>();
			services.AddScoped<IRepository<APizza>, PizzaRepository>();
			services.AddScoped<IRepository<ASize>, SizeRepository>();
			services.AddScoped<IRepository<AStore>, StoreRepository>();
			services.AddScoped<IRepository<ATopping>, ToppingRepository>();

			/*
			var settings = new JsonSerializerSettings();
			settings.Converters.Add(JsonSubtypesConverterBuilder
				.Of<PizzaBox.Domain.Abstracts.ACrust>("CrustType") // type property is only defined here
				.RegisterSubtype<CheeseStuffedCrust>(CRUST_TYPE.CheeseStuffed)
				.RegisterSubtype<DeepDishCrust>(CRUST_TYPE.DeepDish)
				.RegisterSubtype<TraditionalCrust>(CRUST_TYPE.Traditional)
				.SerializeDiscriminatorProperty() // ask to serialize the type property
				.Build());
			*/
			//services.AddControllers().Add


			services.AddControllers().AddNewtonsoftJson(options =>
				{
					options.SerializerSettings.Converters.Add(JsonSubtypesConverterBuilder
						.Of<PizzaBox.Domain.Abstracts.ACrust>("CrustType") // type property is only defined here
						.RegisterSubtype<CheeseStuffedCrust>(CRUST_TYPE.CheeseStuffed)
						.RegisterSubtype<DeepDishCrust>(CRUST_TYPE.DeepDish)
						.RegisterSubtype<TraditionalCrust>(CRUST_TYPE.Traditional)
						.SerializeDiscriminatorProperty() // ask to serialize the type property
						.Build());
					
					options.SerializerSettings.Converters.Add(JsonSubtypesConverterBuilder
						.Of<APizza>("PizzaType")
						.RegisterSubtype<CustomPizza>(PIZZA_TYPE.Custom)
						.RegisterSubtype<MeatPizza>(PIZZA_TYPE.Meat)
						.RegisterSubtype<VeganPizza>(PIZZA_TYPE.Vegan)
						.SerializeDiscriminatorProperty() // ask to serialize the type property
						.Build());

					options.SerializerSettings.Converters.Add(JsonSubtypesConverterBuilder
						.Of<ASize>("SizeType")
						.RegisterSubtype<SmallSize>(SIZE_TYPE.Small)
						.RegisterSubtype<MediumSize>(SIZE_TYPE.Medium)
						.RegisterSubtype<LargeSize>(SIZE_TYPE.Large)
						.SerializeDiscriminatorProperty()
						.Build());

					options.SerializerSettings.Converters.Add(JsonSubtypesConverterBuilder
						.Of<AStore>("StoreType")
						.RegisterSubtype<NewYorkStore>(STORE_TYPE.NewYork)
						.RegisterSubtype<ChicagoStore>(STORE_TYPE.Chicago)
						.SerializeDiscriminatorProperty()
						.Build());

					options.SerializerSettings.Converters.Add(JsonSubtypesConverterBuilder
						.Of<ATopping>("ToppingType")
						.RegisterSubtype<BaconTopping>(TOPPING_TYPE.Bacon)
						.RegisterSubtype<MushroomTopping>(TOPPING_TYPE.Mushroom)
						.RegisterSubtype<OnionTopping>(TOPPING_TYPE.Onion)
						.RegisterSubtype<PepperoniTopping>(TOPPING_TYPE.Pepperoni)
						.SerializeDiscriminatorProperty()
						.Build());
				}
			);

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "p1_nick_nevius", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "p1_nick_nevius v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
