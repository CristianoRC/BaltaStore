CREATE OR REPLACE VIEW public.QueryCutomers AS
SELECT id, firstName ||' '||lastName as Name ,document, email from Customer