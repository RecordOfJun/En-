package view;
import java.awt.*;
import javax.swing.*;

public class buttonPanel extends JPanel {
	private JButton[] numberButton=new JButton[10];
	private JButton negativeButton=new JButton("+/-");
	private JButton floatButton=new JButton(".");
	
	public buttonPanel() {
		setButton();
		setPanel();
	}
	
	//숫자버튼 초기화
	private void setButton() {
		for(int count=1;count<=10;count++) {
			numberButton[count-1]=new JButton(Integer.toString(count%10));
			numberButton[count-1].setBackground(Color.white);
		}
		negativeButton.setBackground(Color.LIGHT_GRAY);
		floatButton.setBackground(Color.LIGHT_GRAY);
	}
	
	private void setPanel() {
		this.setLayout(new GridLayout(4,3,10,10));
		for(int count=0;count<10;count++) {
			this.add(numberButton[count]);
		}
		this.add(negativeButton);
		this.add(numberButton[9]);
		this.add(floatButton);
		
	}
	
	
}
