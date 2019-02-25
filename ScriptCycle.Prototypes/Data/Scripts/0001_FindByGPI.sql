/****** Object:  StoredProcedure [dbo].[FindByGPI]    Script Date: 2/25/2019 7:32:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[FindByGPI]
	-- Add the parameters for the stored procedure here
	@GPI varchar(20)
AS
BEGIN	
	SET NOCOUNT ON;
    SELECT 	  
      FName.[drug_name]
	  ,(Select tcgpi_name from mf2tcgpi_g where tcgpi_id = FName.[generic_product_identifier]) as DisplayName     
      ,FName.[dosage_form]
      ,FName.[strength]
      ,FName.[strength_unit_of_measure]
      ,FName.[generic_product_identifier]      
	  ,NDC.ndc_upc_hri
	  ,FName.[multi_source_code]
	  ,FName.[maintenance_drug_code]
	 
  FROM [mf2name_f] FName	
	join mf2ndc_h NDC on NDC.drug_descriptor_id = FName.drug_descriptor_id
  where generic_product_identifier like @GPI + '%'
  order by generic_product_identifier

END
GO


