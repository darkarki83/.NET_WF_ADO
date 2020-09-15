"use struct"

let HW7 = function() {
    document.write('<div style="text-align: center; margin: 100px">');
    document.write("<table>");
        for(let i = 0; i < 8; i++) {
            document.write('<tr >');
            if (i % 2 == 0) {
                for(let j = 0; j < 4; j++) {
                    document.write('<td class="tdblue"></td>');
                    document.write('<td class="tdgreen"></td>'); 
                }
            }
            else {
                for(let j = 0; j < 4; j++) {
                    document.write('<td class="tdgreen"></td>'); 
                    document.write('<td class="tdblue"></td>');
                }
            }
            document.write('</tr>');
        }
    document.write('</table>');   
    document.write('</div>');
}