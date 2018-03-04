CREATE OR REPLACE FUNCTION public.CheckMail(text)
RETURNS smallint
LANGUAGE plpgsql
AS
$function$
--DECLARE
-- variables
BEGIN
    return cast((Select count(id) from customer c where c.email = $1) as smallint);
END;
$function$
