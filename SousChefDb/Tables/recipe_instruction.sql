CREATE TABLE [cook].[recipe_instruction]
(
	[id] UNIQUEIDENTIFIER NOT NULL,
	[recipe_id] UNIQUEIDENTIFIER NOT NULL,
	[instruction] NVARCHAR(2048) NOT NULL,
	[sequence] INT NOT NULL,
	CONSTRAINT [PK_recipe_instruction] PRIMARY KEY ([id]),
	CONSTRAINT [FK_recipe_instruction_recipe_id] FOREIGN KEY ([recipe_id]) REFERENCES cook.recipe([id])
)
