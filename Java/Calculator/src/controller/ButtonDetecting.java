package controller;
import view.*;
import java.awt.event.*;
import javax.swing.*;
public class ButtonDetecting {
	CalculatorFrame frame;
	TextPanel textPanel;
	ButtonPanel buttonPanel;
	public ButtonDetecting(){
		frame=new CalculatorFrame();
		textPanel=new TextPanel();
		buttonPanel=new ButtonPanel();
	}
	public void start(){
		frame.loadFrame();
		buttonPanel.appendAdapter(new numberAdapter());
	}
	private class numberAdapter extends MouseAdapter{
		public void mouseReleased(MouseEvent e) {
			JButton button=(JButton)e.getSource();
			String character=button.getText();
			System.out.println(character);
			//숫자 받아온걸로 가공
			
			//텍스트 최신화
			textPanel.presentNumber.setText(character);
			//frame.refresh();
		}
	}
}
