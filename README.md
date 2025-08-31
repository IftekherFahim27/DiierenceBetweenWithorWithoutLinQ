# 🚀 LINQ vs Loop in C#/.NET Core — Benchmarking with BenchmarkDotNet

## 📌 Overview
LINQ (Language Integrated Query) is one of the most powerful features of C# — it makes querying and filtering data **clean, readable, and expressive**.  
But… is it **better** than traditional loops when it comes to **performance**? 🤔  

This project benchmarks **LINQ queries** against **manual `foreach` loops** using [BenchmarkDotNet](https://benchmarkdotnet.org/).  

---

## ⚡ Benchmark Code
The benchmark compares filtering a list of 1,000,000 random integers using:
1. **WithLinq** → Filtering using LINQ `.Where()`
2. **WithoutLinq** → Filtering using a traditional `foreach` loop

```csharp
[Benchmark]
public List<int> WithLinq()
{
    return numbers.Where(n => n % 2 == 0 && n > 500).ToList();
}

[Benchmark]
public List<int> WithoutLinq()
{
    var result = new List<int>();
    foreach (var n in numbers)
    {
        if (n % 2 == 0 && n > 500)
        {
            result.Add(n);
        }
    }
    return result;
}
```

---

## 🛠️ Setup Instructions

### 1. Clone the Repository
```bash
git clone https://github.com/your-username/LinqVsLoopBenchmark.git
cd LinqVsLoopBenchmark
```

### 2. Create a Console App (if not cloned)
```bash
dotnet new console -n LinqVsLoopBenchmark
cd LinqVsLoopBenchmark
```

### 3. Install BenchmarkDotNet
```bash
dotnet add package BenchmarkDotNet
```

### 4. Build in **Release Mode** ⚠️
BenchmarkDotNet requires **Release mode** for accurate results (Debug mode will give misleading numbers).  
Run:
```bash
dotnet run -c Release
```

---

## 📊 Benchmark Results

Here’s a sample result from my machine:

```
|    Method   |      Mean |     Error |    StdDev |   Gen0   | Allocated |
|-------------|-----------:|----------:|----------:|---------:|----------:|
| WithLinq    |  35.874 ms | 0.2525 ms | 0.2362 ms |  3900.0  | 15.63 MB  |
| WithoutLinq |  27.453 ms | 0.1801 ms | 0.1685 ms |  3600.0  | 12.25 MB  |
```

---

## ✅ Pros & Cons

### LINQ
**Pros**
- Clean, concise, and expressive syntax
- Works across collections, databases (EF Core), XML, etc.
- Easier to maintain and debug
- Strongly typed with IntelliSense support

**Cons**
- Slightly slower due to overhead (delegates, enumerators, deferred execution)
- Higher memory allocations compared to manual loops
- Performance hit noticeable with very large datasets

---

### Loops (`foreach`)
**Pros**
- Faster execution (no overhead from LINQ abstractions)
- Lower memory allocation
- More predictable performance in tight loops

**Cons**
- More verbose (extra boilerplate code)
- Harder to read and maintain compared to LINQ
- Less expressive for complex queries

---

## 📊 Side-by-Side Comparison

| Feature        | LINQ ✅ | Loop (`foreach`) ✅ |
|----------------|---------|---------------------|
| **Readability** | ✔️ Very high | ❌ Verbose |
| **Performance** | ❌ Slower | ✔️ Faster |
| **Memory**      | ❌ Higher allocation | ✔️ Lower allocation |
| **Maintainability** | ✔️ Easy to maintain | ❌ Harder for complex queries |
| **Flexibility** | ✔️ Works across DB/Collections/XML | ❌ Only in-memory collections |

---

## ⚖️ Conclusion
- For **most business applications**, LINQ is the better choice because it improves **developer productivity, readability, and maintainability**.
- For **high-performance scenarios** (e.g., game engines, real-time analytics, huge datasets), manual loops can give you a performance edge.

👉 LINQ is not always *faster*, but it often makes you a *faster developer*.  

---

## 📌 Run It Yourself
Clone this repo, run the benchmark, and check the results on your machine.  
Don’t forget to always use:
```bash
dotnet run -c Release
```

---

## 🔖 Tags
`C#` `LINQ` `.NET Core` `BenchmarkDotNet` `Performance` `Optimization`
