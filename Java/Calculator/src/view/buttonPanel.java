package view;
import java.awt.*;
import javax.swing.*;

public class buttonPanel extends JPanel {
	private JButton[] numberButton=new JButton[10];
	private JButton negativeButton=new JButton("+/-");
	private JButton floatButton=new JButton(".");
	private JButton[] topButtons=new JButton[4];
	private JButton[] rightButtons=new JButton[4];

	
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
		topButtons[0]=new JButton("CE");
		topButtons[1]=new JButton("C");
		topButtons[2]=new JButton("image/backspace.jpg");
		topButtons[3]=new JButton("÷");
		rightButtons[0]=new JButton("×");
		rightButtons[1]=new JButton("+");
		rightButtons[2]=new JButton("-");
		rightButtons[3]=new JButton("=");
		negativeButton.setBackground(Color.white);
		floatButton.setBackground(Color.white);
	}
	
	private void setPanel() {
		this.setLayout(new GridLayout(5,4,3,3));
		for(int count=0;count<4;count++) {
			topButtons[count].setBackground(Color.lightGray);
			this.add(topButtons[count]);
		}
		int rightCount=0;
		for(int count=0;count<10;count++) {
			if(count%3==0&&count!=0) {
				rightButtons[rightCount].setBackground(Color.lightGray);
				this.add(rightButtons[rightCount]);
				rightCount++;
			}
			this.add(numberButton[count]);
		}
		this.add(negativeButton);
		this.add(numberButton[9]);
		this.add(floatButton);
		rightButtons[rightCount].setBackground(Color.lightGray);
		this.add(rightButtons[rightCount]);
		
	}
	
	
}
