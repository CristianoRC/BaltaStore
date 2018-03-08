CREATE OR REPLACE FUNCTION public.CheckDocument(text)
RETURNS smallint
LANGUAGE plpgsql
AS
$function$
--DECLARE
-- variables BEGIN
    return cast((Select count(id) from customer c where c.document = $1) as smallint);
END;
$function$
