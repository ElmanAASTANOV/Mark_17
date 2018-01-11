namespace Calculator{

public enum Operators{Plus,Minus,Divide,Multiple,Number};

    public class Tree{
          
          private Operators GetOperators(string k){

              switch(k){
                  case "+":
                  return Operators.Plus;
                  
                  case "-":
                  return Operators.Minus;

                  case "x":
                  return Operators.Multiple;

                  case "/":
                  return Operators.Divide;

                  default :
                  return Operators.Number;
              }
          }

        public Node root=null;


        public bool BuildTree(string Expression){
            try{

                string number="";
                foreach(char n in Expression){
             
             if(!char.IsDigit(n) && n!='.'){
                 Add(number);
                 Add(n.ToString());
                 number = "";
                 continue;
             }else {
                 number+=n;
             }          
                 }
            Add(number);
                return true;
            }
            catch{
                return false;
            }
        }
        private void Add(string n){
            Node node;
            
            if(char.IsNumber(n,0))   node = new Node(){Value=System.Convert.ToDouble(n)};
            else node = new Node(){oprt = GetOperators(n)};

            if(root==null) {
                root = node;
                return; 
                } 
             
            if(root.oprt>node.oprt){
                Node h = root;
                root = node;
                Add(h,ref root.Left);
            }
            else{
                Add(node,ref root.Right);
            }
            

        }  
        private void Add(Node node,ref Node _root) {
           if(_root==null) {_root = node; return;}

           if(_root.oprt>node.oprt){
                Node h = _root;
                _root = node;
                Add(h,ref _root.Left);
            } else {
                Add(node,ref _root.Right);
            }
        }
    
        public double Calculate(Node _root){
            if(_root.oprt==Operators.Number) return _root.Value;

            switch(_root.oprt){

                case Operators.Plus:
                return Calculate(_root.Left) + Calculate(_root.Right);

                case Operators.Minus:
                return Calculate(_root.Left) - Calculate(_root.Right);

                case Operators.Multiple:
                return Calculate(_root.Left) * Calculate(_root.Right);

                case Operators.Divide:
                return Calculate(_root.Left) / Calculate(_root.Right);

                default :return 0;
            }
        }


        }



}





