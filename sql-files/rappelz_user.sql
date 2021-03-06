CREATE TABLE IF NOT EXISTS `char` (
  `char_id` int(11) NOT NULL AUTO_INCREMENT,
  `account_id` int(11) NOT NULL,
  `slot` tinyint(4) NOT NULL,
  `name` varchar(20) NOT NULL,
  `sex` int(11) NOT NULL,
  `race` int(11) NOT NULL,
  `hair_id` int(11) NOT NULL,
  `face_id` int(11) NOT NULL,
  `body_id` int(11) NOT NULL,
  `hands_id` int(11) NOT NULL,
  `feet_id` int(11) NOT NULL,
  `face_detail_id` int(11) NOT NULL,
  `hair_color` int(11) NOT NULL,
  `skin_color` int(11) NOT NULL,
  `x` int(11) NOT NULL,
  `y` int(11) NOT NULL,
  `layer` int(11) NOT NULL,
  `save_x` int(11) NOT NULL,
  `save_y` int(11) NOT NULL,
  `level` int(11) NOT NULL,
  `exp` int(11) NOT NULL,
  `job` smallint(5) NOT NULL,
  `job_level` int(11) NOT NULL,
  `job_exp` int(11) NOT NULL,
  `jp` bigint(20) NOT NULL,
  `job_0` int(11) NOT NULL,
  `job0_level` int(11) NOT NULL,
  `job_1` int(11) NOT NULL,
  `job1_level` int(11) NOT NULL,
  `job_2` int(11) NOT NULL,
  `job2_level` int(11) NOT NULL,
  `create_date` int(10) NOT NULL,
  `delete_date` int(10) NOT NULL,
  `client_info` varchar(4096) NOT NULL,
  PRIMARY KEY (`char_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE IF NOT EXISTS `item` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `char_id` int(11) NOT NULL,
  `account_id` int(11) NOT NULL,
  `code` int(11) NOT NULL,
  `count` bigint(20) NOT NULL,
  `equip` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE IF NOT EXISTS `quest` (
  `id` int(11) NOT NULL,
  `quest_id` int(11) NOT NULL,
  `char_id` int(11) NOT NULL,
  `start_text` int(11) NOT NULL,
  `status1` int(11) NOT NULL,
  `status2` int(11) NOT NULL,
  `status3` int(11) NOT NULL,
  `status4` int(11) NOT NULL,
  `status5` int(11) NOT NULL,
  `status6` int(11) NOT NULL,
  `remain_time` int(11) NOT NULL,
  `progress` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `skill` (
  `char_id` int(11) NOT NULL,
  `id` int(11) NOT NULL,
  `level` tinyint(3) unsigned NOT NULL,
  PRIMARY KEY  (`char_id`,`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1;