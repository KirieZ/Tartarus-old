 --============================================================
--             <<<<<< ???? ? NPC >>>>>>
--============================================================

--============================================================
--===============		??? ???
--============================================================
function NPC_Tutorial_Guide_Deva_init()
	cprint( "!??? ??? ??" )
	set_npc_name(  "@90301100"  )
end

function NPC_Tutorial_Guide_Deva_contact()


	-- ????? ??
	dlg_title( "@90301101" )

	-- ??? ????. ??? 3, ?? 4, ??? 5
	local race = get_value( "race" )
	-- ??? ?? ?? 	get_quest_progress(ID)  
	-- ??? -1 : ???? ??  /  0 : ???  /  1 : ???  /  2 : ????  /  255 : ????
	local quest_progress1 =  get_quest_progress(1005)
	local quest_progress2 =  get_quest_progress(1006)
	local quest_progress3 =  get_quest_progress(1007)

	-- ???? ??? ???
	if race ~= 4 then
		dlg_text( "@90301102" )

	-- ??? ??? ?????(??????)
	elseif quest_progress1 == 0 then
		dlg_text( "@90301103" )
		
		
	-- ??? ??? ?????
	elseif quest_progress3 == 255 then
		dlg_text( "@90301105" )

	-- ? ?? ??(1~2 ?? ? ???? ????  1~3?? ??? ?????? ?? ??...)
	else
		dlg_text( "@90301104" )
	
	end
	
	-- ?? ???? ???
		dlg_menu( "@90301124", "Quest_Link_1_1d()" )		
	-- ???? ? ?? ?? ???
		dlg_menu( "@91000463", "Quest_Link_1_1e()" )
		
	--?? ?? (???? ?? ?? ???? ?? ??? ??? ?? ??)
	-- ? ?? ???? ?? ?? ???...(??, ????? ????)
	if quest_progress1 == 1 or quest_progress1 == 2 or quest_progress1 == 255 then
		-- HP? ?????
		dlg_menu( "@90010034", "Quest_Link_1_1a()" )
		-- ???? ???
		dlg_menu( "@90010035", "Quest_Link_1_1b()" )
		-- ?? ??, ???? ?????
		dlg_menu( "@90301126", "Quest_Link_1_1c()" )
		
	end
	-- ? ?? ??? ???.
	if quest_progress1 == 255 then
		-- ???? ?? ????
		dlg_menu( "@90010036", "Quest_Link_1_2as()" )
	end
	-- ? ?? ??? ???.
	if quest_progress2 == 255 then
		-- ??? ?? ????
		dlg_menu( "@90010037", "Quest_Link_1_2bs()" )
	end
	-- ? ?? ???? ?? ?? ???...(??, ????? ????)
	if quest_progress3 == 1 or quest_progress3 == 2 or quest_progress3 == 255 then
		-- ???? ?? ??
		dlg_menu( "@90010038", "Quest_Link_1_3a()" )
	end
	
		-- ???? 
		dlg_menu( "@90010002", " " )
 
	dlg_show()
 
end
 

-- ??? 1-1 ?? ????
function Quest_Link_1_1()

	-- ????? ??
	dlg_title( "@90301101" )

	dlg_text_without_quest_menu( "@90301114" )
	
	-- HP? ?????
	dlg_menu( "@90010034", "Quest_Link_1_1a()" )
	-- ???? ???
	dlg_menu( "@90010035", "Quest_Link_1_1b()" )
	-- ?? ??, ???? ?????
	dlg_menu( "@90301126", "Quest_Link_1_1c()" )
	
	-- ???? 
	dlg_menu( "@90010002", " " )
 
	dlg_show()
 
end


-- ???? 1-1a 	HP,LV? ??
function Quest_Link_1_1a()

	-- ????? ??
	dlg_title( "@90301101" )

	dlg_text_without_quest_menu( "@90301106" )
	
	-- ???? ???
	dlg_menu( "@90010035", "Quest_Link_1_1b()" )
	-- ?? ??, ???? ?????
	dlg_menu( "@90301126", "Quest_Link_1_1c()" )

	-- ???? 
	dlg_menu( "@90010002", " " )
 
	dlg_show()
end

 
-- ???? 1-1b 	??? ???
function Quest_Link_1_1b()

	-- ????? ??
	dlg_title( "@90301101" )

	dlg_text_without_quest_menu( "@90301107" )
	
	-- HP? ?????
	dlg_menu( "@90010034", "Quest_Link_1_1a()" )
	-- ?? ??, ???? ?????
	dlg_menu( "@90301126", "Quest_Link_1_1c()" )

	-- ???? 
	dlg_menu( "@90010002", " " )
 
	dlg_show()
end

-- ???? 1-1c 	?? ??, ???? ???
function Quest_Link_1_1c()

	-- ????? ??
	dlg_title( "@90301101" )

	dlg_text_without_quest_menu( "@90301127" )
	
	-- HP? ?????
	dlg_menu( "@90010034", "Quest_Link_1_1a()" )
	-- ???? ???
	dlg_menu( "@90010035", "Quest_Link_1_1b()" )
	
	-- ???? 
	dlg_menu( "@90010002", " " )
 
	dlg_show()
end

-- ???? 1-1d 	???? ? - ?? ???
function Quest_Link_1_1d()

	-- ????? ??
	dlg_title( "@90301101" )

	dlg_text_without_quest_menu( "@90301125" )
	
	-- ????
	--dlg_menu( "@90010003", "NPC_Tutorial_Guide_Deva_contact()" )

	
	-- ???? 
	dlg_menu( "@90010002", " " )
 
	dlg_show()
end

-- ???? 1-1e 	???? ? ?? ?? ??
function Quest_Link_1_1e()

	-- ????? ??
	dlg_title( "@90301101" )

	dlg_text_without_quest_menu( "@91000464" )
	
	-- ????
	--dlg_menu( "@90010003", "NPC_Tutorial_Guide_Deva_contact()" )

	
	-- ???? 
	dlg_menu( "@90010002", " " )
 
	dlg_show()
end

-- ?? ?? ??? ??. (?? 3?? 10?, ID 1011)  ???? ?? => add_state( ????ID, ??, ?? )
function Quest_Link_1_2a()
	add_state( 1011, 3, 60000 )
	Quest_Link_1_2as()
end
-- ???? 1-2a ??? ??
function Quest_Link_1_2as()

	-- ????? ??
	dlg_title( "@90301101" )

	dlg_text( "@90301108" )
	
	-- ???? 
	dlg_menu( "@90010002", " " )
 
	dlg_show()

end


-- ?? ?? ??? ??. (?? 3?? 20?, ID 1013)  ???? ?? => add_state( ????ID, ??, ?? )
function Quest_Link_1_2b()
	add_state( 1013, 3, 120000 )
	Quest_Link_1_2bs()
end
-- ???? 1-2b ?? ???
function Quest_Link_1_2bs()

	-- ????? ??
	dlg_title( "@90301101" )

	dlg_text( "@90301109" )
	
	-- ???? 
	dlg_menu( "@90010002", " " )
 
	dlg_show()
end


-- ???? 1-3a ??? ???
function Quest_Link_1_3a()
	-- ????? ??
	dlg_title( "@90301101" )

	dlg_text_without_quest_menu( "@90301110" )
	
	-- ???? 
	dlg_menu( "@90010002", " " )
 
	dlg_show()

end

-- ???? 1-4 ?????? ????
function Quest_Link_1_4()

	local npc_id

	-- NPC ID? ????.
	npc_id = get_npc_id()

	-- NPC ?? ??
	-- ??? ? ? (3013	??? ????)
	if npc_id == 3013 then
		dlg_title("@90301301")
	-- ?? ? ? (	3011 ??? ???)
	elseif npc_id == 3011 then
		dlg_title("@90301101")
	-- ??? ? ? (3012 ??? ???)
	elseif npc_id == 3012 then
		dlg_title("@90301201")
	end

	-- start of "??? ?? NPC ??"
	-- ??? ? ? (3013	??? ????)
	if npc_id == 3013 then
		dlg_text_without_quest_menu("@90301322")
	-- ?? ? ? (	3011 ??? ???)
	elseif npc_id == 3011 then
		dlg_text_without_quest_menu("@90301122")
	-- ??? ? ? (3012 ??? ???)
	elseif npc_id == 3012 then
		dlg_text_without_quest_menu("@90301222")
	end -- end of "??? ?? NPC ??"

	-- ?? ??.
	dlg_menu( "@90010002", "" )

	dlg_show()
	
end