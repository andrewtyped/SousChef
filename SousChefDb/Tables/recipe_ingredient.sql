CREATE TABLE [cook].[recipe_ingredient]
(
	[id] UNIQUEIDENTIFIER NOT NULL,
	[recipe_id] UNIQUEIDENTIFIER NOT NULL,
	[ingredient] NVARCHAR(256) NOT NULL,
	[quantity] DECIMAL(18,2) NOT NULL DEFAULT 0.0,
	[unit] NVARCHAR(32) NOT NULL DEFAULT N'',
	[raw_text] NVARCHAR(256) NOT NULL,
	CONSTRAINT [PK_recipe_ingredient] PRIMARY KEY ([id]),
	CONSTRAINT [FK_recipe_ingredient_recipe_id] FOREIGN KEY([recipe_id]) REFERENCES cook.recipe([id])
)
