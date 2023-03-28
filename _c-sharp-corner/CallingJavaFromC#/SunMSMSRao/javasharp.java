import java.awt.*;
import java.awt.event.*;
class javasharp extends Frame implements ActionListener,Runnable
{
Button b=new Button("c#");
String s="Hello C# how are you?....    .....     .....     .... ";
Font ff=new Font("Arial",Font.BOLD,15);
javasharp()
   {
      super("java");
      setLayout(new BorderLayout());
      setBackground(Color.cyan);
      setForeground(Color.red);
      setFont(ff);
      add("South",b);
      addWindowListener(new WindowEventHandler());
      b.addActionListener(this);
    }
public void run()
    {
       char ch;
       for(;;)
         {
            try{
                repaint();
                Thread.sleep(250);
                ch=s.charAt(0);
                s=s.substring(1,s.length());
                s+=ch;
               }catch(Exception e){}
          }
     }
 public void paint(Graphics g)
    {
     g.drawString(s,30,90);
    }
 public static void main(String a[])
   {
      javasharp ff=new javasharp();
      Thread t=new Thread(ff);
      ff.setSize(200,200);
      ff.setVisible(true);
      t.start();
   }

public void actionPerformed(ActionEvent e)
   {
      try
        {
          Runtime r=Runtime.getRuntime();
          r.exec("p.exe");
        }catch(Exception e1){}
   }

class WindowEventHandler extends WindowAdapter
   {
       public void windowClosing(WindowEvent e)
          {
             System.exit(0);
          }
   }
}
