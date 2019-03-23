<?php
	
	function remove_UTF8_BOM($string) { 
		
		if(substr($string, 0,3) == pack("CCC", 0xef, 0xbb, 0xbf)) { 
		  $string = substr($string, 3); 
		} 
		return $string; 
		
	}
	
	function big_levenshtein($str1, $str2, $cost_ins = null, $cost_rep = null, $cost_del = null) {
		
		$d = array_fill(0, strlen($str1) + 1, array_fill(0, strlen($str2) + 1, 0));
		$ret = 0;
       
		for ($i = 1; $i < strlen($str1) + 1; $i++) {
		  $d[$i][0] = $i;
		}
		for ($j = 1; $j < strlen($str2) + 1; $j++) {
		  $d[0][$j] = $j;
		}
       
		for ($i = 1; $i < strlen($str1) + 1; $i++) {
		  for ($j = 1; $j < strlen($str2) + 1; $j++) {
			$c = 1;
			if ($str1{$i - 1} == $str2{$j - 1}) $c = 0;
            $d[$i][$j] = min($d[$i - 1][$j] + 1, $d[$i][$j - 1] + 1, $d[$i - 1][$j - 1] + $c);
            $ret = $d[$i][$j];
		  }
        }
   
		return $ret;
	
	}
	
	// Break in spaces, punctuation marks, and brackets (tags)
	
	function ass_explode($string) {
		
		if (mb_strpos($string, ' ') === false) {
		  $out2[0] = array('word' => $string, 'delimiter' => '');
		}
		else {
		  $out = explode(' ', $string);
		  $i = 0;
		  foreach ($out as $v) {
		    $out2[$i]['word'] = $v;
		    $out2[$i]['delimiter'] = ' ';
		    $i++;
		  }
		  $out2[$i-1]['delimiter'] = '';
		}
		
		$i = 0;
		foreach ($out2 as $v) {
		  $extra_split = preg_split('/([\;\,\!\-\.\{\}])|(\\\N)|(\\\n)+/', $v['word'], 0, 
		  PREG_SPLIT_DELIM_CAPTURE + PREG_SPLIT_NO_EMPTY);
		  if (count($extra_split) == 1) {
		    $out3[$i] = $v;
			$i++;
		  }
		  else {
		    foreach ($extra_split as $v2) {
		      $out3[$i]['word'] = $v2;
			  $out3[$i]['delimiter'] = '';
			  $i++;
		    }
			$out3[$i-1]['delimiter'] = $v['delimiter'];
		  }
		}
		
		return $out3;
		
	}
	
	
	// Load an ASS file into an array. Maximum allowed size 1MB.
	
	function load_ass_subs ($filename) {
	
		$raw_data = file_get_contents($filename, false, null, -1, 1048576);
		if (!$raw_data) die('Cannot load file ' . $filename . '!');
		$lines = explode("\r\n", $raw_data);
		
		$i = 0;
		foreach ($lines as $line) {
		  
		  if (substr($line, 0, 10) == 'Dialogue: ') {
			
			$comma_pos[0] = strpos($line, ',');
			
			for ($k = 1; $k <= 8; $k++) {
			  $comma_pos[$k] = strpos($line, ',', $comma_pos[$k-1] + 1);
			}
			
			$text = substr($line, $comma_pos[8] + 1);
			if (!empty($text)) {
			  $out[$i]['text'] = $text;
			  $out[$i]['start'] = substr($line, $comma_pos[0] + 1, $comma_pos[1] - $comma_pos[0] - 1);
			  $out[$i]['end'] = substr($line, $comma_pos[1] + 1, $comma_pos[2] - $comma_pos[1] - 1);
			  $out[$i]['stripped_text'] = preg_replace('/\{.*?\}/', '', $out[$i]['text']);
			  $out[$i]['text_len'] = strlen($out[$i]['text']);
			  $out[$i]['stripped_text_len'] = strlen($out[$i]['stripped_text']);
			  $i++;
			}
		  }
	    }
		
		return $out;
		
	}
	
	// Load an SRT file into an array. Maximum allowed size 1MB.
	
	function load_srt_subs ($filename) {
	
		$raw_data = file_get_contents($filename, false, null, -1, 1048576);
		if (!$raw_data) die('Cannot load file ' . $filename . '!');
		$raw_data = remove_UTF8_BOM($raw_data);
		$lines = explode("\r\n", $raw_data);
		
		$i = 0;
		$line_buffer = '';
		foreach ($lines as $line) {

		  if ($line == $i + 1) {
		    if ($i > 0) {
			  $out[$i-1]['text'] = $line_buffer;
			  $out[$i-1]['stripped_text'] = preg_replace('/\{.*?\}/', '', $line_buffer);
			  $out[$i-1]['text_len'] = strlen($line_buffer);
			  $out[$i-1]['stripped_text_len'] = strlen($out[$i-1]['stripped_text']);
		    }
		    $line_buffer = '';
		    $i++;
		  }
		  elseif ((strpos($line, '-->') > 0)&&(strpos($line, ':') > 0)&&(strpos($line, ',') > 0)) {
		    //00:05:47,530 --> 00:05:49,330
		    $timestamps = explode(' --> ', str_replace(',', '.', $line));
		    $tp = explode(':', substr($timestamps[0], 0, -1));
		    $out[$i-1]['start'] = (int) $tp[0] . ':' . $tp[1] . ':' . $tp[2];
		    $tp = explode(':', substr($timestamps[1], 0, -1));
		    $out[$i-1]['end'] = (int) $tp[0] . ':' . $tp[1] . ':' . $tp[2];
		  }
		  elseif (!empty($line)) {
 		    if (!empty($line_buffer)) $line_buffer .= '\N';
		    $line_buffer .= $line;
		  }
		}
		
		return $out;
		
	}
	
	// Detects the file extension of a subtitles file and calls the appropriate loading function
	
	function load_subs ($filename) {
	
		$extension = substr($filename, -4);
		if (($extension == '.ass')||($extension == '.ssa')) {
		  return load_ass_subs($filename);
		}
		elseif ($extension == '.srt') {
		  return load_srt_subs($filename);
		}
		else {
		  die ('Invalid extension in file: ' . basename($filename));
		}
		
	}
	
	// Find text differences
	
	function text_diff($arr) {
	  
	  	$size1 = count($arr[0]);
		$size2 = count($arr[1]);
		$best_index1 = -1;
		$best_index2 = -1;
		$best_length = 0;
		$best_chars = 0;
		
		$i = 0;
		foreach ($arr[0] as $v) {
		  $line[0][$i]['word'] = $v['word'];
		  $line[0][$i]['matched'] = false;
		  $line[0][$i]['delimiter'] = $v['delimiter'];
		  $i++;
		}
		
		$i = 0;
		foreach ($arr[1] as $v) {
		  $line[1][$i]['word'] = $v['word'];
		  $line[1][$i]['matched'] = false;
		  $line[1][$i]['delimiter'] = $v['delimiter'];
		  $i++;
		}		
		
		for ($i = 0; $i < $size1; $i++) {
	      for ($j = 0; $j < $size2;$j++) {
			$common_length = min($size1 - $i, $size2 - $j);
			$match_length = 0;
			$match_chars = 0;
			for ($l = 0; $l < $common_length; $l++) {
			if ($line[0][$i+$l]['word'] == $line[1][$j+$l]['word']) {
			  if ($match_chars > 0) $match_chars++;
			  $match_chars = $match_chars + mb_strlen($line[0][$i+$l]['word']);
			  $match_length++;
			}
			else {
			  break;
			}
			}
			if ($match_chars > $best_chars) {
			  $best_chars = $match_chars;
			  $best_length = $match_length;
			  $best_index1 = $i;
			  $best_index2 = $j;
			}
		  }
		}

		if ($best_length > 0) {
		  for ($i = 0; $i < $best_length; $i++) {
		    $line[0][$i+$best_index1]['matched'] = true;
		    $line[1][$i+$best_index2]['matched'] = true;
		  }
		  if (($best_index1 > 0)&&($best_index2 > 0)) {
		  
			for ($i = 0; $i < $best_index1; $i++) {
		      $linepart1[0][$i]['word'] = $line[0][$i]['word'];
			  $linepart1[0][$i]['delimiter'] = $line[0][$i]['delimiter'];
		    }
		    for ($i = 0; $i < $best_index2; $i++) {
		      $linepart1[1][$i]['word'] = $line[1][$i]['word'];
			  $linepart1[1][$i]['delimiter'] = $line[1][$i]['delimiter'];
		    }
		    $linepart1 = text_diff($linepart1);
		    for ($i = 0; $i < $best_index1; $i++) {
		      $line[0][$i]['matched'] = $linepart1[0][$i]['matched'];
		    }
		    for ($i = 0; $i < $best_index2; $i++) {
		      $line[1][$i]['matched'] = $linepart1[1][$i]['matched'];
		    }
		  }
		  if (($best_index1 < $size1 - $best_length)&&($best_index2 < $size2 - $best_length)) {
		    for ($i = $best_index1 + $best_length; $i < $size1; $i++) {
		      $linepart2[0][$i - $best_index1 - $best_length]['word'] = $line[0][$i]['word'];
			  $linepart2[0][$i - $best_index1 - $best_length]['delimiter'] = $line[0][$i]['delimiter'];
		    }
		    for ($i = $best_index2 + $best_length; $i < $size2; $i++) {
		      $linepart2[1][$i - $best_index2 - $best_length]['word'] = $line[1][$i]['word'];
			  $linepart2[1][$i - $best_index2 - $best_length]['delimiter'] = $line[1][$i]['delimiter'];
		    }
			$linepart2 = text_diff($linepart2);
		    for ($i = $best_index1 + $best_length; $i < $size1; $i++) {
		      $line[0][$i]['matched'] = $linepart2[0][$i - $best_index1 - $best_length]['matched'];
		    }
		    for ($i = $best_index2 + $best_length; $i < $size2; $i++) {
		      $line[1][$i]['matched'] = $linepart2[1][$i - $best_index2 - $best_length]['matched'];
		    }
		  }
		}
		
		return $line;
	  
	}

	// Format text differences in HTML
	
	function display_text_diff($data, $css_class) {
	
		foreach ($data as $element) {
		  if ($element['matched'] === false) {
			$out .= '<span class="' . $css_class . '">' . $element['word'] . '</span>' .
					$element['delimiter'];
		  }
		  else {
		    $out .= '<span>' . $element['word'] . '</span>' . $element['delimiter'];
		  }
		}
		return $out;
		
	}
	
	// Format time differences in HTML
	
	function display_time_diff($time, $time_compare, $css_class) {
	  $len = strlen($time);
	  $i = $len;
  	  while(substr($time, 0, $i) != substr($time_compare, 0, $i)) $i--;
	  if ($i == $len) {
	    return '<span>' . $time . '</span>';
	  }
	  else {
	    return '<span>' . substr($time, 0, $i) . '</span>' . 
		'<span class="' . $css_class . '">' . substr($time, $i) .  '</span>';
	  }
	}
	
	// Format text differences in HTML (whole line)
	
	function display_simple_text_diff($line, $line_compare, $css_class) {
	  if ($line == $line_compare) {
	    return '<span>' . $line . '</span>';
	  }
	  else {
	    return '<span class="' . $css_class . '">' . $line . '</span>';
	  }
	}
	
	// Calculate the difference between 2 timestamps

	function time_diff ($timestamp1, $timestamp2) {
		
		//0:00:42.80
		$p1 = explode(':', $timestamp1);
		$p2 = explode(':', $timestamp2);
		
		$h1 = (float) $p1[0];
		$h2 = (float) $p2[0];
		$m1 = (float) $p1[1];
		$m2 = (float) $p2[1];
		$s1 = (float) $p1[2];
		$s2 = (float) $p2[2];
		
		$t1 = $h1 * 3600 + $m1 * 60 + $s1;
		$t2 = $h2 * 3600 + $m2 * 60 + $s2;
		
		return abs($t1 - $t2);
		
	}
	
	function display_aegis_table($data) {
		
		$table_header = "\t" . 	'<table width="100%">' . "\r\n" .
						"\t" . 	'  <tr>' . "\r\n" .
						"\t" . 	'	<th class="col1">#</th>' . "\r\n" .
						"\t" . 	'	<th class="col2">Start</th>' . "\r\n" .
						"\t" . 	'	<th class="col2">End</th>' . "\r\n" .
						"\t" . 	'	<th class="col3">Text</th>' . "\r\n" .
						"\t" . 	'  </tr>' . "\r\n";
		
		foreach ($data as $row) {
		  if ($row['number'] > 0) {
			$table_row	  = "\t" .  '  <tr>' . "\r\n" .
							"\t" .	'	<td class="col1">' . $row['number'] . '</td>' . "\r\n" .
							"\t" .	'	<td class="col2">' . $row['start'] . '</td>' . "\r\n" .
							"\t" .	'	<td class="col2">' . $row['end'] . '</td>' . "\r\n" .
							"\t" .	'	<td>' . $row['text'] . '</td>' . "\r\n" .
							"\t" .	'  </tr>' . "\r\n";
		  }
		  else {
			$table_row	  = "\t" .  '  <tr>' . "\r\n" .
							"\t" .	'	<td class="emptycol" colspan="4">&nbsp;</td>' . "\r\n" .
							"\t" .	'  </tr>' . "\r\n";
		  }
			$table_content .= $table_row;
			
		}

		$table_footer = "\t" .	'</table>' . "\r\n";
		
		return $table_header . $table_content . $table_footer;
		
	}
	
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
  <head>
	<title>Ass diff</title>
	<style>
	  <!--
	  body {
	    font-family: Verdana,Helvetica,sans-serif;
		font-size: 11px;
		background-color: #EFEFEF;
	  }
	  .green {
	    font-weight: bold;
		color: green;
	  }
	  .red {
	    font-weight: bold;
		color: red;
	  }
	  table {
		border-width: 0px;
		border-collapse: collapse;
		border-spacing: 0px;
		padding: 2px;
	  }
	  td, th {
		border-width: 1px;
		border-style: solid;
		border-color: #808080;
		padding: 2px;
		vertical-align: top;
		background-color: white;
	  }
	  th {
	    font-weight: normal;
		text-align: center;
		vertical-align: top;
		background-color: #A5CFE7;
	  }
	  th.col1 {
	    width: 25px;
	  }
	  th.col2 {
	    width: 70px;
	  }
	  th.col3 {
	    text-align: left;
		padding-left: 5px;
	  }
	  td.col1, td.col2 {
	    text-align: center;
		vertical-align: top;
		font-size: 10px;
	  }
	  td.col1 {
	    background-color: #C4ECC9;
	  }
	  td.emptycol {
		border-width: 0px;
		background-color: transparent;
	  }
	  -->
	</style>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
  </head>
  <body>

<?php
	
	if (isset($_GET['file1'])&&!empty($_GET['file1'])&&isset($_GET['file2'])&&!empty($_GET['file2'])) {
	  $file1 = urldecode($_GET['file1']);
	  $file2 = urldecode($_GET['file2']);
	}
	else {
	  die ('No files specified!');
	}
	
	$ass[0] = load_subs($file1);
	$ass[1] = load_subs($file2);
	
	$time_start = microtime(true);
	
	$total_lines1 = count($ass[0]);
	$total_lines2 = count($ass[1]);
	if ($total_lines1 < 2) die ('Invalid script 1!');
	if ($total_lines2 < 2) die ('Invalid script 2!');

	$lines_ratio = (float) ($total_lines2 - 1) / ($total_lines1 - 1);
	
	$changed_lines = 0;
	$changed_only_timings = 0;
	$changed_timings = 0;
	$changed_texts = 0;
	$changed_both = 0;
	$out = '';
	
	echo 'File 1: ' . basename($file1) . '<br />' . "\r\n";
	echo 'Lines: ' . $total_lines1 . '<br />' . "\r\n" . '<br />' . "\r\n";
	echo 'File 2: ' . basename($file2) . '<br />' . "\r\n";
	echo 'Lines: ' . $total_lines2 . '<br />' . "\r\n" . '<br />' . "\r\n";
	
	$k = 0;
	$average_timeshift = (float) 0;
	
	for ($i = 0; $i < $total_lines1; $i++) {
	  $min_diff = (float) 1000000;
	  $min_time_diff = (float) 0;
	  $best = 0;
	  $change_type = 0;
	  $center_j = (int) round($i * $lines_ratio);
	  $scanned_lines = 0;
	  $scan_vector = -1;
	  $scan_distance = 0;
	  //for ($j = 0; $j < $total_lines2; $j++) {
	  while ($scanned_lines < $total_lines2) {
	    
		$scan_vector = - $scan_vector;
		$j = $center_j + $scan_vector * $scan_distance;
		if ($scan_distance == 0) $scan_distance = 1;
		elseif ($scan_vector == 1) $scan_distance++;
		if (($j < 0)||($j >= $total_lines2)) continue;
		else $scanned_lines++;
		
		$diff1 = time_diff($ass[0][$i]['start'], $ass[1][$j]['start']);
		if ($diff1 >= $min_diff) continue;
		$diff2 = time_diff($ass[0][$i]['end'], $ass[1][$j]['end']);
		if ($diff2 >= $min_diff) continue;
		if (($ass[0][$i]['stripped_text_len'] < 255)&&($ass[1][$i]['stripped_text_len'] < 255)) {
		  $diff3 = levenshtein($ass[0][$i]['stripped_text'], $ass[1][$j]['stripped_text']);
		}
		else {
		  $diff3 = big_levenshtein($ass[0][$i]['stripped_text'], $ass[1][$j]['stripped_text']);
		}
		if ($diff3 >= $min_diff) continue;
		if (($ass[0][$i]['text_len'] < 255)&&($ass[1][$i]['text_len'] < 255)) {
		  $diff4 = levenshtein($ass[0][$i]['text'], $ass[1][$j]['text']) / 10;
		}
		else {
		  $diff4 = big_levenshtein($ass[0][$i]['text'], $ass[1][$j]['text']) / 10;
		}
		
		
		$time_diff = $diff1 + $diff2;
		$text_diff = $diff3 + $diff4;
		$total_diff = $time_diff + $text_diff;
		
		if ($total_diff == 0) {
		  $best = $j;
		  $min_diff = 0;
		  $min_time_diff = $time_diff;
		  break;
		}
		elseif ($time_diff < 0.5) {
		  $best = $j;
		  $min_diff = $total_diff;
		  $min_time_diff = $time_diff;
		  if (($diff4 == 0) && ($time_diff > 0)) $change_type = 1;
		  elseif (($diff4 > 0) && ($time_diff == 0)) $change_type = 2;
		  elseif (($diff4 > 0)&&($time_diff > 0)) $change_type = 3;
		  break;
		}
		elseif ($total_diff < $min_diff) {
		  $best = $j;
		  $min_diff = $total_diff;
		  $min_time_diff = $time_diff;
		  if (($diff4 == 0) && ($time_diff > 0)) $change_type = 1;
		  elseif (($diff4 > 0) && ($time_diff == 0)) $change_type = 2;
		  elseif (($diff4 > 0)&&($time_diff > 0)) $change_type = 3;
		}
	  }
	  if ($min_diff > 0) {
	    $changed_lines++;
		$average_timeshift = $average_timeshift + $min_time_diff;
		if ($change_type == 1) {
		  $changed_only_timings++;
		  $changed_timings++;
		}
		elseif ($change_type == 2) {
		  $changed_only_texts++;
		  $changed_texts++;
		}
		elseif ($change_type == 3) {
		  $changed_timings++;
		  $changed_texts++;
		  $changed_both++;
		}
		
		$arr[0] = ass_explode($ass[0][$i]['text']);
		$arr[1] = ass_explode($ass[1][$best]['text']);
		$text_array = text_diff($arr);
		
		$data[$k]['number'] = $i + 1;
		$data[$k]['start'] = display_time_diff($ass[0][$i]['start'], $ass[1][$best]['start'], 'red');
		$data[$k]['end'] = display_time_diff($ass[0][$i]['end'], $ass[1][$best]['end'], 'red');
		$data[$k]['text'] = display_text_diff($text_array[0], 'red');
		
		$k++;
		
		$data[$k]['number'] = $best + 1;
		$data[$k]['start'] = display_time_diff($ass[1][$best]['start'], $ass[0][$i]['start'], 'green');
		$data[$k]['end'] = display_time_diff($ass[1][$best]['end'], $ass[0][$i]['end'], 'green');
		$data[$k]['text'] = display_text_diff($text_array[1], 'green');
		
		$k++;
		
		$data[$k]['number'] = 0;
		$data[$k]['start'] = '';
		$data[$k]['end'] = '';
		$data[$k]['text'] = '';
		
		$k++;
		
		/*
		$out .= display_time_diff($ass[0][$i]['start'], $ass[1][$best]['start'], 'red') . "\t" . 
		display_time_diff($ass[0][$i]['end'], $ass[1][$best]['end'], 'red') . "\t" .
		display_text_diff($text_array[0], 'red') . '<br />' . "\r\n";

		$out .= display_time_diff($ass[1][$best]['start'], $ass[0][$i]['start'], 'green') . "\t" . 
		display_time_diff($ass[1][$best]['end'], $ass[0][$i]['end'], 'green') . "\t" .
		display_text_diff($text_array[1], 'green') . '<br />' . "\r\n";
		
		$out .= '<br />' . "\r\n";
		*/
		
	  }
	}

	$average_timeshift = $average_timeshift / $total_lines1 / 2;
	
	$time_elapsed = round(microtime(true) - $time_start, 3);
	
	echo 'Total changed lines: ' . $changed_lines . '<br />' . "\r\n";
	echo 'Total changed timings: ' . $changed_timings . ' ';
	echo '(average time shift: ' . round($average_timeshift, 2) . ' sec)' . '<br />' . "\r\n";
	if ($average_timeshift > 1) {
	  echo '<span class="red">WARNING: Average time shift is very high. ';
	  echo 'The results are possibly wrong!</span><br />' . "\r\n";
	}
	echo 'Total changed texts: ' . $changed_texts . '<br />' . "\r\n";
	echo 'Lines with changes ONLY in timings: ' . $changed_only_timings . '<br />' . "\r\n";
	echo 'Lines with changes ONLY in texts: ' . $changed_only_texts . '<br />' . "\r\n";
	echo 'Lines with changes in BOTH timings and texts: ' . $changed_both . '<br />' . "\r\n";
	echo '<br />' . "\r\n";
	echo 'Processed in ' . $time_elapsed . ' sec' . '<br />' . "\r\n";
	echo '<br />' . "\r\n";
	
	echo display_aegis_table($data);
	
	//echo $out;

?>
  </body>
</html>