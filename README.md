# Bacheca
Una bacheca raggiungibile da più client
- La distinzione tra "pubblico" e "privato" si ottiene distinguendo quali messaggi sono visibili da tutti e quali no.
	In pratica, se un utente vuole far sapere ad altri determinati messaggi, questi saranno "pubblici", altrimenti sono "privati".
	Di principio ogni bacheca possiede un nome unico, e conoscendo il nome è possibile visualizzare dall'esterno la bacheca se questa non fosse condivisa.

- Ogni file si chiamerà con una sigla 


- Forma pacchetto (nome - caratteri): 
	----------------------------------------------------------------------------------
	username 32 | bacheca 16 | visibilità 1 | lunghezza 8 | tipo 1 | data | testo 255
	----------------------------------------------------------------------------------
		   
	Username - il nome dell'utente che scrive il messaggio.
	Visibilità - indica se il messaggio che viene inviato
