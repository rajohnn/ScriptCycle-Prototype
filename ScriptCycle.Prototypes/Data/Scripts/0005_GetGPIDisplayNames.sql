/****** Object:  StoredProcedure [dbo].[GetGPIDisplayNames]    Script Date: 2/25/2019 7:40:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[GetGPIDisplayNames]
	@List as dbo.GPIList READONLY
as
begin
	set nocount on;	
	Select tcgpi_id, tcgpi_name from mf2tcgpi_g where tcgpi_id in (select GPI from @List)
end
GO