package controller;
import view.ButtonPanel;
import view.TextPanel;
import view.CalculatorFrame;
import java.awt.event.*;
import javax.swing.*;
import utility.Constant;
public class ButtonDetecting {
	private CalculatorFrame frame;
	private TextPanel textPanel;
	private ButtonPanel buttonPanel;
	private Calculation calculation;
	public ButtonDetecting(){
		frame=new CalculatorFrame();
		textPanel=frame.calculatings;
		buttonPanel=frame.buttons;
		calculation=new Calculation();
	}
	public void start(){
		frame.loadFrame();
		buttonPanel.appendAdapter(new numberAdapter());
	}
	public class numberAdapter extends MouseAdapter{
		public void mouseReleased(MouseEvent e) {
			String character=getButtonText(e);
			switchButton(character);
			//숫자 받아온걸로 가공
			//텍스트 최신화
			textPanel.presentNumber.setText(calculation.status.getNumber());
			textPanel.calculateLog.setText(calculation.status.getUpFieldText());
		}
	}
	private String getButtonText(MouseEvent e) {
		JButton button=(JButton)e.getSource();
		return button.getText();
	}
	private void switchButton(String character) {
		switch(character) {
			case"C":
				calculation.initAll();
				System.out.println("전체 초기화");
				break;
			case"CE":
				calculation.initLast();
				System.out.println("직전 수 초기화");
				break;
			case".":
				calculation.detectDot();
				System.out.println("콤마");
				break;
			case"+/-":
				calculation.appendSign();
				System.out.println("부호전환");
				break;
			case"=":
				calculation.detectEqual();
				//직전 숫자만 삭제
				System.out.println("계산");
				break;
			case"\u232B":
				calculation.detectBackSpace();
				System.out.println("백스페이스");
				break;	
			case"÷": case"×": case"+": case"-":
				//직전 숫자만 삭제
				calculation.detectOperator(character);
				System.out.println("연산자");
				break;
			default:
				calculation.detectNumber(character);
				System.out.println("숫자");
				break;
			
		}
	}
}
